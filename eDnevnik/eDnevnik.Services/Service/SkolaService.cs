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
    public class SkolaService : BaseCRUDService<Model.Models.Skola, Database.Skola, SkolaSearchObject, SkolaInsertRequest, SkolaUpdateRequest, SkolaDeleteRequest>, ISkolaService
    {
        public SkolaService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Skola> AddFilter(IQueryable<Skola> query, SkolaSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.nazivSkole))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.nazivSkole));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.Naziv.Contains(search.nazivSkole));
            }

            return base.AddFilter(query, search);
        }
    }
}
