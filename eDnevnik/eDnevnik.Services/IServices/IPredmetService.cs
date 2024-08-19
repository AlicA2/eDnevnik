using eDnevnik.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IPredmetService : ICRUDService<Model.Models.Predmet, Model.SearchObjects.PredmetSearchObject, Model.Requests.PredmetInsertRequest, Model.Requests.PredmetUpdateRequest, Model.Requests.PredmetDeleteRequest>
    {
        Task<Model.Models.Predmet> Activate(int id);
        Task<Model.Models.Predmet> Hide(int id);
        Task<List<string>> AllowedActions(int id);
        Task<bool> AddOcjena(int predmetID, OcjeneInsertRequest request);

    }
}
