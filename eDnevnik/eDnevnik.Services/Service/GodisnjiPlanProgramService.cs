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
    public class GodisnjiPlanProgramService : BaseCRUDService<Model.Models.GodisnjiPlanProgram, Database.GodisnjiPlanProgram, GodisnjiPlanProgramSearchObject, GodisnjiPlanProgramInsertRequest, GodisnjiPlanProgramUpdateRequest, GodisnjiPlanProgramDeleteRequest>, IGodisnjiPlanProgramService
    {
        public GodisnjiPlanProgramService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public override IQueryable<GodisnjiPlanProgram> AddFilter(IQueryable<GodisnjiPlanProgram> query, GodisnjiPlanProgramSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(search.FTS))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return base.AddFilter(query, search);
        }
    }
}
