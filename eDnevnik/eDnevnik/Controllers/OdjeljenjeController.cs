using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class OdjeljenjeController : BaseCRUDController<Model.Models.Odjeljenje, Model.SearchObjects.OdjeljenjeSearchObject, Model.Requests.OdjeljenjeInsertRequest, Model.Requests.OdjeljenjeUpdateRequest, Model.Requests.OdjeljenjeDeleteRequest>
    {
        public OdjeljenjeController(ILogger<BaseController<Odjeljenje, OdjeljenjeSearchObject>> logger, IOdjeljenjeService service) : base(logger, service)
        {
        }
    }
}
