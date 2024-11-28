using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class KorisniciUlogeService : BaseCRUDService<Model.Models.KorisniciUloge, Database.KorisniciUloge, KorisniciUlogeSearchObject, KorisniciUlogeInsertRequest, KorisniciUlogeUpdateRequest, KorisniciUlogeDeleteRequest>, IKorisniciUlogeService
    {
        public KorisniciUlogeService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<KorisniciUloge> AddFilter(IQueryable<KorisniciUloge> query, KorisniciUlogeSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.KorisnikUlogaID.HasValue)
                {
                    query = query.Where(x => x.KorisnikUlogaID == search.KorisnikUlogaID.Value);
                }
                if (search.KorisnikID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.KorisnikID.Value);
                }
                if (search.UlogaID.HasValue)
                {
                    query = query.Where(x => x.UlogaID == search.UlogaID.Value);
                }
            }
            return base.AddFilter(query, search);
        }
    }
}
