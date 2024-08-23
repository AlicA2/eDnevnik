using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IOcjeneService : ICRUDService<Model.Models.Ocjene, Model.SearchObjects.OcjeneSearchObject, Model.Requests.OcjeneInsertRequest, Model.Requests.OcjeneUpdateRequest, Model.Requests.OcjeneDeleteRequest>
    {
        Task<bool> HasUsers(int korisnikID);
    }
}
