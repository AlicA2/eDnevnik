using AutoMapper;
using eDnevnik.Model;
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
        public override async Task<Model.Models.OdjeljenjePredmet> Delete(int id, OdjeljenjePredmetDeleteRequest deleteRequest)
        {
            var odjeljenjePredmet = await _context.OdjeljenjePredmet.FindAsync(id);

            if (odjeljenjePredmet == null)
            {
                throw new UserException("OdjeljenjePredmet nije pronađen.");
            }

            var godisnjiPlanProgram = await _context.GodisnjiPlanProgram
                .Include(g => g.Casovi)
                .FirstOrDefaultAsync(g => g.OdjeljenjeID == odjeljenjePredmet.OdjeljenjeID
                                           && g.PredmetID == odjeljenjePredmet.PredmetID);

            if (godisnjiPlanProgram != null)
            {
                if (godisnjiPlanProgram.Casovi.Any(c => c.IsOdrzan))
                {
                    throw new UserException("Ne možete izbrisati OdjeljenjePredmet zato što postoje Casovi koji su održani.");
                }
            }

            return await base.Delete(id, deleteRequest);
        }
    }
}
