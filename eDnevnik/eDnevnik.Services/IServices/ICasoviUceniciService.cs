using eDnevnik.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface ICasoviUceniciService : ICRUDService<Model.Models.CasoviUcenici, Model.SearchObjects.CasoviUceniciSearchObject, Model.Requests.CasoviUceniciInsertRequest, Model.Requests.CasoviUceniciUpdateRequest, Model.Requests.CasoviUceniciDeleteRequest>
    {
        //Task UpdateAttendance(int casoviID, List<CasoviUceniciInsertRequest> attendanceList);
    }
}
