using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class CasoviController : BaseCRUDController<Model.Models.Casovi, Model.SearchObjects.CasoviSearchObject, Model.Requests.CasoviInsertRequest, Model.Requests.CasoviUpdateRequest, Model.Requests.CasoviDeleteRequest>
    {
        public CasoviController(ILogger<BaseController<Casovi, CasoviSearchObject>> logger, ICasoviService service)
            : base(logger, service)
        {
        }
    }
}
