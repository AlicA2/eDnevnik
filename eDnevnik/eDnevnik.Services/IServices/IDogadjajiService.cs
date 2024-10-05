using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IDogadjajiService : ICRUDService<Model.Models.Dogadjaji, Model.SearchObjects.DogadjajiSearchObject, Model.Requests.DogadjajiInsertRequest, Model.Requests.DogadjajiUpdateRequest, Model.Requests.DogadjajiDeleteRequest>
    {
        Task<Model.Models.Dogadjaji> Activate(int id);
        Task<Model.Models.Dogadjaji> Hide(int id);
        Task<List<string>> AllowedActions(int id);
        List<Model.Models.Dogadjaji> Recommend(int id);
    }
}
