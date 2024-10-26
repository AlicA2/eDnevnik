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
    public class ZakljucnaOcjenaService : BaseCRUDService<Model.Models.ZakljucnaOcjena, Database.ZakljucnaOcjena, ZakljucnaOcjenaSearchObject, ZakljucnaOcjenaInsertRequest, ZakljucnaOcjenaUpdateRequest, ZakljucnaOcjenaDeleteRequest>, IZakljucnaOcjenaService
    {
        public ZakljucnaOcjenaService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<ZakljucnaOcjena> AddFilter(IQueryable<ZakljucnaOcjena> query, ZakljucnaOcjenaSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.KorisnikID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.KorisnikID.Value);
                }
                if (search.PredmetID.HasValue)
                {
                    query = query.Where(x => x.PredmetID == search.PredmetID.Value);
                }
            }
            return base.AddFilter(query, search);
        }
    }
}
