using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class KorisniciUlogeController : BaseCRUDController<Model.Models.KorisniciUloge, Model.SearchObjects.KorisniciUlogeSearchObject, Model.Requests.KorisniciUlogeInsertRequest, Model.Requests.KorisniciUlogeUpdateRequest, Model.Requests.KorisniciUlogeDeleteRequest>
    {
        public KorisniciUlogeController(ILogger<BaseController<KorisniciUloge, KorisniciUlogeSearchObject>> logger, IKorisniciUlogeService service) : base(logger, service)
        {
        }
    }
}
