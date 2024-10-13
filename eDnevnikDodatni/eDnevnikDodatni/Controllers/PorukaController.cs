using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace eDnevnik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PorukaController : ControllerBase
    {
        private readonly eDnevnikDBContext _context;

        private readonly IPorukeService _porukeService;
        private readonly IKorisnikService _korisniciService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PorukaController(IPorukeService porukeService, IKorisnikService korisniciService, IMapper mapper, IConfiguration configuration, eDnevnikDBContext context)
        {
            _porukeService = porukeService;
            _korisniciService = korisniciService;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var poruke = await _porukeService.Get(new PorukeSearchObject());
            if (poruke == null || poruke.Count == 0)
            {
                return NotFound("No messages found.");
            }

            return Ok(poruke);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessagesById(int id)
        {
            var poruke = await _porukeService.GetById(id);
            if (poruke == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }

            return Ok(poruke);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PorukaInsertRequest request)
        {
            if (ModelState.IsValid)
            {
                var poruke = new eDnevnik.Services.Database.Poruke
                {
                    ProfesorID = request.ProfesorID,
                    UcenikID = request.UcenikID,
                    SadrzajPoruke = request.SadrzajPoruke,
                    DatumSlanja = request.DatumSlanja,
                };

                _context.Poruke.Add(poruke);
                await _context.SaveChangesAsync();

                await SendMessageToRabbitMQ(poruke.PorukaID, request.SadrzajPoruke);

                return CreatedAtAction(nameof(GetMessagesById), new { id = poruke.PorukaID }, poruke);
            }

            return BadRequest(ModelState);
        }

        private async Task SendMessageToRabbitMQ(int kontaktId, string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RABBITMQ_HOST"] ?? "rabbitMQ",
                UserName = _configuration["RABBITMQ_USERNAME"] ?? "guest",
                Password = _configuration["RABBITMQ_PASSWORD"] ?? "guest",
                VirtualHost = _configuration["RABBITMQ_VIRTUALHOST"] ?? "/"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "kontakt_notifications",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: true,
                                 arguments: null);

            var notification = new { KontaktId = kontaktId, Message = message };
            var json = JsonSerializer.Serialize(notification);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "kontakt_notifications",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[x] Sent {message} for kontakt {kontaktId}");
        }
    }
}