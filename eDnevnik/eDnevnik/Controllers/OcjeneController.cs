using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class OcjeneController : BaseCRUDController<Model.Models.Ocjene, Model.SearchObjects.OcjeneSearchObject, Model.Requests.OcjeneInsertRequest, Model.Requests.OcjeneUpdateRequest, Model.Requests.OcjeneDeleteRequest>
    {
        public OcjeneController(ILogger<BaseController<Ocjene, OcjeneSearchObject>> logger, IOcjeneService service)
            : base(logger, service)
        {
        }
    }
}
