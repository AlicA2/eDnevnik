using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class KorisnikDogadjajController : BaseCRUDController<Model.Models.KorisnikDogadjaj, Model.SearchObjects.KorisnikDogadjajSearchObject, Model.Requests.KorisnikDogadjajInsertRequest, Model.Requests.KorisnikDogadjajUpdateRequest, Model.Requests.KorisnikDogadjajDeleteRequest>
    {
        public KorisnikDogadjajController(ILogger<BaseController<KorisnikDogadjaj, KorisnikDogadjajSearchObject>> logger, IKorisnikDogadjajService service)
            : base(logger, service)
        {
        }
    }
}
