using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class OcjeneController : BaseCRUDController<Model.Models.Ocjene, Model.SearchObjects.OcjeneSearchObject, Model.Requests.OcjeneInsertRequest, Model.Requests.OcjeneUpdateRequest, Model.Requests.OcjeneDeleteRequest>
    {
        private readonly IOcjeneService _ocjeneService;

        public OcjeneController(ILogger<BaseController<Ocjene, OcjeneSearchObject>> logger, IOcjeneService service)
            : base(logger, service)
        {
            _ocjeneService = service;
        }

        [HttpGet("check")]
        public async Task<IActionResult> HasUsers([FromQuery] int korisnikID)
        {
            var hasUsers = await _ocjeneService.HasUsers(korisnikID);
            return Ok(new { hasUsers });
        }
    }
}
