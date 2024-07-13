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
    public class CasoviService : BaseCRUDService<Model.Models.Casovi, Database.Casovi, CasoviSearchObject, CasoviInsertRequest, CasoviUpdateRequest, CasoviDeleteRequest>, ICasoviService
    {
        public CasoviService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Casovi> AddFilter(IQueryable<Casovi> query, CasoviSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                query = query.Where(x => x.NazivCasa.StartsWith(search.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.NazivCasa.Contains(search.Naziv));
            }

            return base.AddFilter(query, search);
        }
    }
}
