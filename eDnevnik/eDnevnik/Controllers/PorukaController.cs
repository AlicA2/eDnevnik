using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class PorukaController : BaseCRUDController<Model.Models.Poruka, Model.SearchObjects.PorukeSearchObject, Model.Requests.PorukaInsertRequest, Model.Requests.PorukaUpdateRequest, Model.Requests.PorukeDeleteRequest>
    {
        public PorukaController(ILogger<BaseController<Poruka, PorukeSearchObject>> logger, IPorukeService service)
            :base(logger, service)
        {
        }
    }
}
