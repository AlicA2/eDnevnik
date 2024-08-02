using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class GodisnjiPlanProgramController : BaseCRUDController<Model.Models.GodisnjiPlanProgram, Model.SearchObjects.GodisnjiPlanProgramSearchObject, Model.Requests.GodisnjiPlanProgramInsertRequest, Model.Requests.GodisnjiPlanProgramUpdateRequest, Model.Requests.GodisnjiPlanProgramDeleteRequest>
    {
        private readonly IGodisnjiPlanProgramService _service;

        public GodisnjiPlanProgramController(ILogger<BaseController<GodisnjiPlanProgram, GodisnjiPlanProgramSearchObject>> logger, IGodisnjiPlanProgramService service)
            : base(logger, service)
        {
            _service = service;
        }

        [HttpGet("CheckIfExists")]
        public async Task<IActionResult> CheckIfExists(int odjeljenjeID, int predmetID)
        {
            var exists = await _service.CheckIfExists(odjeljenjeID, predmetID);
            return Ok(new { exists });
        }
    }
}
