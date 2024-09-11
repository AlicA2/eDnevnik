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
    public class PorukeService : BaseCRUDService<Model.Models.Poruka, Database.Poruke, PorukeSearchObject, PorukaInsertRequest, PorukaUpdateRequest, PorukeDeleteRequest>, IPorukeService
    {
        public PorukeService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<Poruke> AddFilter(IQueryable<Poruke> query, PorukeSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(x => x.SadrzajPoruke.StartsWith(search.Naziv));
                }
                if (!string.IsNullOrWhiteSpace(search.FTS))
                {
                    query = query.Where(x => x.SadrzajPoruke.Contains(search.Naziv));
                }
                if (search.ProfesorID.HasValue)
                {
                    query = query.Where(x => x.ProfesorID == search.ProfesorID.Value);
                }
                if (search.UcenikID.HasValue)
                {
                    query = query.Where(x => x.UcenikID == search.UcenikID.Value);
                }
            }
            return base.AddFilter(query, search);
        }

    }
}
