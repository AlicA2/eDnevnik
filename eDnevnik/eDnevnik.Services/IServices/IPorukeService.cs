using eDnevnik.Model.Models;
using eDnevnik.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IPorukeService : ICRUDService<Model.Models.Poruka, Model.SearchObjects.PorukeSearchObject, Model.Requests.PorukaInsertRequest, Model.Requests.PorukaUpdateRequest, Model.Requests.PorukeDeleteRequest>
    {
    }
}
