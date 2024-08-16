using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class OdjeljenjePredmetController : BaseCRUDController<Model.Models.OdjeljenjePredmet, Model.SearchObjects.OdjeljenjePredmetSearchObject, Model.Requests.OdjeljenjePredmetInsertRequest, Model.Requests.OdjeljenjePredmetUpdateRequest, Model.Requests.OdjeljenjePredmetDeleteRequest>
    {
        public OdjeljenjePredmetController(ILogger<BaseController<OdjeljenjePredmet, OdjeljenjePredmetSearchObject>> logger, IOdjeljenjePredmetService service) : base(logger, service)
        {
        }
    }
}
