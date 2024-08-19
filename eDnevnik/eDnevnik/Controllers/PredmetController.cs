using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class PredmetController : BaseCRUDController<Model.Models.Predmet, PredmetSearchObject, PredmetInsertRequest, PredmetUpdateRequest, PredmetDeleteRequest>
    {
        private readonly IPredmetService _predmetService;

        public PredmetController(ILogger<BaseController<Predmet, PredmetSearchObject>> logger, IPredmetService service) : base(logger, service)
        {
            _predmetService = service;
        }

        [HttpPost("AddOcjena")]
        public async Task<IActionResult> AddOcjena(int predmetID, [FromBody] OcjeneInsertRequest request)
        {
            try
            {
                var result = await _predmetService.AddOcjena(predmetID, request);
                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/activate")]
        public virtual async Task<Model.Models.Predmet> Activate(int id)
        {
            return await (_service as IPredmetService).Activate(id);
        }

        [HttpPut("{id}/hide")]
        public virtual async Task<Model.Models.Predmet> Hide(int id)
        {
            return await (_service as IPredmetService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IPredmetService).AllowedActions(id);
        }
    }
}
