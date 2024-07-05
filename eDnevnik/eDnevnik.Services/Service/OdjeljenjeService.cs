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
    public class OdjeljenjeService : BaseCRUDService<Model.Models.Odjeljenje, Database.Odjeljenje, OdjeljenjeSearchObject, OdjeljenjeInsertRequest, OdjeljenjeUpdateRequest, OdjeljenjeDeleteRequest>, IOdjeljenjeService
    {
        public OdjeljenjeService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Odjeljenje> AddFilter(IQueryable<Odjeljenje> query, OdjeljenjeSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.NazivOdjeljenja))
            {
                query = query.Where(x => x.NazivOdjeljenja.StartsWith(search.NazivOdjeljenja));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.NazivOdjeljenja.Contains(search.NazivOdjeljenja));
            }

            return base.AddFilter(query, search);
        }
        public override IQueryable<Odjeljenje> AddInclude(IQueryable<Odjeljenje> query, OdjeljenjeSearchObject? search = null)
        {
            if (search?.isUceniciIncluded == true)
            {
                query = query.Include("Ucenici");
            }
            return base.AddInclude(query, search);
        }
    }
}
