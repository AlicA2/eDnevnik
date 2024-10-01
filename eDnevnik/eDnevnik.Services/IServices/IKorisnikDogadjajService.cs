using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IKorisnikDogadjajService : ICRUDService<Model.Models.KorisnikDogadjaj, Model.SearchObjects.KorisnikDogadjajSearchObject, Model.Requests.KorisnikDogadjajInsertRequest, Model.Requests.KorisnikDogadjajUpdateRequest, Model.Requests.KorisnikDogadjajDeleteRequest>
    {
    }
}
