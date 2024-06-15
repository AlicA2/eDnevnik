using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IPredmetService : ICRUDService<Model.Models.Predmet, Model.SearchObjects.PredmetSearchObject, Model.Requests.PredmetInsertRequest, Model.Requests.PredmetUpdateRequest>
    {

    }
}
