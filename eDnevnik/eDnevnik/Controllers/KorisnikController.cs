using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class KorisnikController : BaseCRUDController<Model.Models.Korisnik, Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest, Model.Requests.KorisniciDeleteRequest>
    {
        public KorisnikController(ILogger<BaseController<Korisnik, Model.SearchObjects.KorisnikSearchObject>> logger, IKorisnikService service) : base(logger, service)
        {
        }

        [Authorize(Roles = "admin")]
        public override Task<Korisnik> Insert([FromBody] KorisniciInsertRequest insert)
        {
            return base.Insert(insert);
        }
    } 
}