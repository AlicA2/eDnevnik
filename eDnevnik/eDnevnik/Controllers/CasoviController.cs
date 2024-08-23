using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class CasoviController : BaseCRUDController<Model.Models.Casovi, Model.SearchObjects.CasoviSearchObject, Model.Requests.CasoviInsertRequest, Model.Requests.CasoviUpdateRequest, Model.Requests.CasoviDeleteRequest>
    {
        private readonly ICasoviService _casoviService;

        public CasoviController(ILogger<BaseController<Casovi, CasoviSearchObject>> logger, ICasoviService service)
            : base(logger, service)
        {
            _casoviService = service;
        }

        [HttpGet("check")]
        public async Task<IActionResult> HasClasses([FromQuery] int godisnjiPlanProgramID)
        {
            var hasClasses = await _casoviService.HasClasses(godisnjiPlanProgramID);
            return Ok(new { hasClasses });
        }
    }
}
