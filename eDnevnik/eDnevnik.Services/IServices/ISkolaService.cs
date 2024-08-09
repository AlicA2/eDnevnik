using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface ISkolaService : ICRUDService<Model.Models.Skola, Model.SearchObjects.SkolaSearchObject, Model.Requests.SkolaInsertRequest, Model.Requests.SkolaUpdateRequest, Model.Requests.SkolaDeleteRequest>
    {
    }
}
