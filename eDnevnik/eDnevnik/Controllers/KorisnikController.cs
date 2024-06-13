using eDnevnik.Model.Requests;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;
        private readonly ILogger<WeatherForecastController> _logger;
        public KorisnikController(ILogger<WeatherForecastController> logger, IKorisnikService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public async Task<IEnumerable<Model.Models.Korisnik>> Get()
        {
            return await _service.Get();
        }
        [HttpPost()]
        public Model.Models.Korisnik Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut()]
        public Model.Models.Korisnik Update(int id, KorisniciUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}