using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface ISkolskaGodinaService : ICRUDService<Model.Models.SkolskaGodina, Model.SearchObjects.SkolskaGodinaSearchObject, Model.Requests.SkolskaGodinaInsertRequest, Model.Requests.SkolskaGodinaUpdateRequest, Model.Requests.SkolskaGodinaDeleteRequest>
    {
    }
}
