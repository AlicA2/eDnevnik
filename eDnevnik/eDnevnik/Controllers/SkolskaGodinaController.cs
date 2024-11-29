using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class SkolskaGodinaController : BaseCRUDController<Model.Models.SkolskaGodina, Model.SearchObjects.SkolskaGodinaSearchObject, Model.Requests.SkolskaGodinaInsertRequest, Model.Requests.SkolskaGodinaUpdateRequest, Model.Requests.SkolskaGodinaDeleteRequest>
    {
        public SkolskaGodinaController(ILogger<BaseController<SkolskaGodina, SkolskaGodinaSearchObject>> logger, ISkolskaGodinaService service) : base(logger, service)
        {
        }
    }
}
