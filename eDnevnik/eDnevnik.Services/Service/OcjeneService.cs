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
    public class OcjeneService : BaseCRUDService<Model.Models.Ocjene, Database.Ocjene, OcjeneSearchObject, OcjeneInsertRequest, OcjeneUpdateRequest, OcjeneDeleteRequest>, IOcjeneService
    {
        public OcjeneService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public async Task<bool> HasUsers(int korisnikID)
        {
            return await _context.Ocjene
                .AnyAsync(c => c.KorisnikID == korisnikID);
        }
        public override IQueryable<Ocjene> AddFilter(IQueryable<Ocjene> query, OcjeneSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.PredmetID.HasValue)
                {
                    query = query.Where(x => x.PredmetID == search.PredmetID.Value);
                }
                if (search.ProfesorID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.ProfesorID.Value);
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
