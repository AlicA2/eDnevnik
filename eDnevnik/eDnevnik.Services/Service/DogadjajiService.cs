using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class DogadjajiService : BaseCRUDService<Model.Models.Dogadjaji, Database.Dogadjaji, DogadjajiSearchObject, DogadjajiInsertRequest, DogadjajiUpdateRequest, DogadjajiDeleteRequest>, IDogadjajiService
    {
        public DogadjajiService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Dogadjaji> AddFilter(IQueryable<Dogadjaji> query, DogadjajiSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.NazivDogadjaja))
                {
                    query = query.Where(x => x.NazivDogadjaja.StartsWith(search.NazivDogadjaja));
                }
                if (!string.IsNullOrWhiteSpace(search.OpisDogadjaja))
                {
                    query = query.Where(x => x.OpisDogadjaja.Contains(search.OpisDogadjaja));
                }
                if (search.DogadjajId.HasValue)
                {
                    query = query.Where(x => x.DogadjajId == search.DogadjajId.Value);
                }
            }

            return base.AddFilter(query, search);
        }
    }
}
