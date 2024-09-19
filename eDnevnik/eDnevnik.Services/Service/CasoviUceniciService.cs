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
    public class CasoviUceniciService : BaseCRUDService<Model.Models.CasoviUcenici, Database.CasoviUcenici, CasoviUceniciSearchObject, CasoviUceniciInsertRequest, CasoviUceniciUpdateRequest, CasoviUceniciDeleteRequest>, ICasoviUceniciService
    {
        public CasoviUceniciService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<CasoviUcenici> AddFilter(IQueryable<CasoviUcenici> query, CasoviUceniciSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.UcenikID.HasValue)
                {
                    query = query.Where(x => x.UcenikID == search.UcenikID.Value);
                }
                if (search.CasoviID.HasValue)
                {
                    query = query.Where(x => x.CasoviID == search.CasoviID.Value);
                }
                if (search.IsPrisutan.HasValue)
                {
                    query = query.Where(x => x.IsPrisutan == search.IsPrisutan.Value);
                }
            }

            return base.AddFilter(query, search);
        }
    }
}
