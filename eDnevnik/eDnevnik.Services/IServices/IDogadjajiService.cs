using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IDogadjajiService : ICRUDService<Model.Models.Dogadjaji, Model.SearchObjects.DogadjajiSearchObject, Model.Requests.DogadjajiInsertRequest, Model.Requests.DogadjajiUpdateRequest, Model.Requests.DogadjajiDeleteRequest>
    {
    }
}
