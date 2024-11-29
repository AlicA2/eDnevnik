using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class KorisnikDetaljiController : BaseCRUDController<Model.Models.KorisnikDetalji, Model.SearchObjects.KorisnikDetaljiSearchObject, Model.Requests.KorisnikDetaljiInsertRequest, Model.Requests.KorisnikDetaljiUpdateRequest, Model.Requests.KorisnikDetaljiDeleteRequest>
    {
        public KorisnikDetaljiController(ILogger<BaseController<KorisnikDetalji, KorisnikDetaljiSearchObject>> logger, IKorisnikDetaljiService service)
            : base(logger, service)
        {
        }
    }
}
