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
        [HttpPut("{id}/activate")]
        public virtual async Task<Model.Models.Dogadjaji> Activate(int id)
        {
            return await (_service as IDogadjajiService).Activate(id);
        }

        [HttpPut("{id}/hide")]
        public virtual async Task<Model.Models.Dogadjaji> Hide(int id)
        {
            return await (_service as IDogadjajiService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IDogadjajiService).AllowedActions(id);
        }

        [HttpGet("{id}/recommend")]
        public virtual List<Model.Models.Dogadjaji> Recommend(int id)
        {
            return (_service as IDogadjajiService).Recommend(id);
        }

        [HttpGet("{id}/korisniciDogadjaji")]
        public async Task<List<Model.Models.KorisnikDogadjaj>> GetKorisniciDogadjaji(int id)
        {
            return await (_service as IDogadjajiService).GetKorisniciDogadjaji(id);
        }

    }
}
