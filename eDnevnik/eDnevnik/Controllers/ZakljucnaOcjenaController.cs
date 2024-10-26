using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class ZakljucnaOcjenaController : BaseCRUDController<Model.Models.ZakljucnaOcjena, Model.SearchObjects.ZakljucnaOcjenaSearchObject, Model.Requests.ZakljucnaOcjenaInsertRequest, Model.Requests.ZakljucnaOcjenaUpdateRequest, Model.Requests.ZakljucnaOcjenaDeleteRequest>
    {
        public ZakljucnaOcjenaController(ILogger<BaseController<ZakljucnaOcjena, ZakljucnaOcjenaSearchObject>> logger, IZakljucnaOcjenaService service) : base(logger, service)
        {
        }
    }
}
