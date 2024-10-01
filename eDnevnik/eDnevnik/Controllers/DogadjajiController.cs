using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class DogadjajiController : BaseCRUDController<Model.Models.Dogadjaji, Model.SearchObjects.DogadjajiSearchObject, Model.Requests.DogadjajiInsertRequest, Model.Requests.DogadjajiUpdateRequest, Model.Requests.DogadjajiDeleteRequest>
    {
        public DogadjajiController(ILogger<BaseController<Dogadjaji, DogadjajiSearchObject>> logger, IDogadjajiService service)
            : base(logger, service)
        {
        }
    }
}
