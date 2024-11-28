using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IKorisniciUlogeService : ICRUDService<Model.Models.KorisniciUloge, Model.SearchObjects.KorisniciUlogeSearchObject, Model.Requests.KorisniciUlogeInsertRequest, Model.Requests.KorisniciUlogeUpdateRequest, Model.Requests.KorisniciUlogeDeleteRequest>
    {
    }
}
