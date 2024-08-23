using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface ICasoviService : ICRUDService<Model.Models.Casovi, Model.SearchObjects.CasoviSearchObject, Model.Requests.CasoviInsertRequest, Model.Requests.CasoviUpdateRequest, Model.Requests.CasoviDeleteRequest>
    {
        Task<bool> HasClasses(int godisnjiPlanProgramID);
    }
}
