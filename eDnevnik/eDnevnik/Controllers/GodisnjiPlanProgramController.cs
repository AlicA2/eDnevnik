using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class GodisnjiPlanProgramController : BaseCRUDController<Model.Models.GodisnjiPlanProgram, Model.SearchObjects.GodisnjiPlanProgramSearchObject, Model.Requests.GodisnjiPlanProgramInsertRequest, Model.Requests.GodisnjiPlanProgramUpdateRequest, Model.Requests.GodisnjiPlanProgramDeleteRequest>
    {
        public GodisnjiPlanProgramController(ILogger<BaseController<GodisnjiPlanProgram, GodisnjiPlanProgramSearchObject>> logger, IGodisnjiPlanProgramService service)
            : base(logger, service)
        {
        }
    }
}
