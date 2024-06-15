using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class PredmetController : BaseCRUDController<Model.Models.Predmet, PredmetSearchObject, PredmetInsertRequest, PredmetUpdateRequest>
    {
        public PredmetController(ILogger<BaseController<Predmet, PredmetSearchObject>> logger, IPredmetService service) : base(logger, service)
        {
        }
    }
}
