using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IKorisnikDetaljiService : ICRUDService<Model.Models.KorisnikDetalji, Model.SearchObjects.KorisnikDetaljiSearchObject, Model.Requests.KorisnikDetaljiInsertRequest, Model.Requests.KorisnikDetaljiUpdateRequest, Model.Requests.KorisnikDetaljiDeleteRequest>
    {
    }
}
