using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.IServices
{
    public interface IZakljucnaOcjenaService : ICRUDService<Model.Models.ZakljucnaOcjena, Model.SearchObjects.ZakljucnaOcjenaSearchObject, Model.Requests.ZakljucnaOcjenaInsertRequest, Model.Requests.ZakljucnaOcjenaUpdateRequest, Model.Requests.ZakljucnaOcjenaDeleteRequest>
    {
    }
}
