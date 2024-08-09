using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class SkolaController : BaseCRUDController<Model.Models.Skola, Model.SearchObjects.SkolaSearchObject, Model.Requests.SkolaInsertRequest, Model.Requests.SkolaUpdateRequest, Model.Requests.SkolaDeleteRequest>
    {
        public SkolaController(ILogger<BaseController<Skola, SkolaSearchObject>> logger, ISkolaService service) : base(logger, service)
        {
        }
    }
}
