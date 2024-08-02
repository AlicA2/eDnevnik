using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IGodisnjiPlanProgramService : ICRUDService<Model.Models.GodisnjiPlanProgram, Model.SearchObjects.GodisnjiPlanProgramSearchObject, Model.Requests.GodisnjiPlanProgramInsertRequest, Model.Requests.GodisnjiPlanProgramUpdateRequest, Model.Requests.GodisnjiPlanProgramDeleteRequest>
    {
        Task<bool> CheckIfExists(int OdjeljenjeID, int PredmetID);
    }
}
