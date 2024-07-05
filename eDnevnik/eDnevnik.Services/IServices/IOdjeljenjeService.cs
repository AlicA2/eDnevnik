using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IOdjeljenjeService : ICRUDService<Model.Models.Odjeljenje, Model.SearchObjects.OdjeljenjeSearchObject, Model.Requests.OdjeljenjeInsertRequest, Model.Requests.OdjeljenjeUpdateRequest, Model.Requests.OdjeljenjeDeleteRequest>
    {
    }
}
