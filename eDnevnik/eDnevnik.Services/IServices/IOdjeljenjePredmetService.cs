using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IOdjeljenjePredmetService : ICRUDService<Model.Models.OdjeljenjePredmet, Model.SearchObjects.OdjeljenjePredmetSearchObject, Model.Requests.OdjeljenjePredmetInsertRequest, Model.Requests.OdjeljenjePredmetUpdateRequest, Model.Requests.OdjeljenjePredmetDeleteRequest>
    {
    }
}
