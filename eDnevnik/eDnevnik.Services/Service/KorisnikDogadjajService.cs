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
    public class KorisnikDogadjajService : BaseCRUDService<Model.Models.KorisnikDogadjaj, Database.KorisnikDogadjaj, KorisnikDogadjajSearchObject, KorisnikDogadjajInsertRequest, KorisnikDogadjajUpdateRequest, KorisnikDogadjajDeleteRequest>, IKorisnikDogadjajService
    {
        public KorisnikDogadjajService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<KorisnikDogadjaj> AddFilter(IQueryable<KorisnikDogadjaj> query, KorisnikDogadjajSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.DogadjajId.HasValue)
                {
                    query = query.Where(x => x.DogadjajId == search.DogadjajId.Value);
                }
                if (search.KorisnikID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.KorisnikID.Value);
                }
            }

            return base.AddFilter(query, search);
        }
    }
}
