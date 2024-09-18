using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class CasoviUceniciController : BaseCRUDController<Model.Models.CasoviUcenici, Model.SearchObjects.CasoviUceniciSearchObject, Model.Requests.CasoviUceniciInsertRequest, Model.Requests.CasoviUceniciUpdateRequest, Model.Requests.CasoviUceniciDeleteRequest>
    {
        private readonly ICasoviUceniciService _service;

        public CasoviUceniciController(ILogger<BaseController<CasoviUcenici, CasoviUceniciSearchObject>> logger, ICasoviUceniciService service)
            : base(logger, service)
        {
            _service = service;
        }
    }
}
