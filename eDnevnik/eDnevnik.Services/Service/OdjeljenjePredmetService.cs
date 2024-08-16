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
    public class OdjeljenjePredmetService : BaseCRUDService<Model.Models.OdjeljenjePredmet, Database.OdjeljenjePredmet, OdjeljenjePredmetSearchObject, OdjeljenjePredmetInsertRequest, OdjeljenjePredmetUpdateRequest, OdjeljenjePredmetDeleteRequest>, IOdjeljenjePredmetService
    {
        public OdjeljenjePredmetService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<OdjeljenjePredmet> AddFilter(IQueryable<OdjeljenjePredmet> query, OdjeljenjePredmetSearchObject? search = null)
        {
            if (search != null)
            {
                if (search.OdjeljenjeID.HasValue)
                {
                    query = query.Where(x => x.OdjeljenjeID == search.OdjeljenjeID.Value);
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
