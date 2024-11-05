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
    public class CasoviService : BaseCRUDService<Model.Models.Casovi, Database.Casovi, CasoviSearchObject, CasoviInsertRequest, CasoviUpdateRequest, CasoviDeleteRequest>, ICasoviService
    {
        public CasoviService(eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public async Task<bool> HasClasses(int godisnjiPlanProgramID)
        {
            return await _context.Casovi
                .AnyAsync(c => c.GodisnjiPlanProgramID == godisnjiPlanProgramID);
        }
        public override IQueryable<Casovi> AddFilter(IQueryable<Casovi> query, CasoviSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(x => x.NazivCasa.StartsWith(search.Naziv));
                }
                if (!string.IsNullOrWhiteSpace(search.FTS))
                {
                    query = query.Where(x => x.NazivCasa.Contains(search.FTS));
                }
                if (search.GodisnjiPlanProgramID.HasValue)
                {
                    query = query.Where(x => x.GodisnjiPlanProgramID == search.GodisnjiPlanProgramID.Value);
                }
                if (search.SkolaID.HasValue)
                {
                    query = query.Where(x => x.GodisnjiPlanProgram.SkolaID == search.SkolaID.Value);
                }
                if (search.ProfesorID.HasValue)
                {
                    query = query.Where(x => x.GodisnjiPlanProgram.ProfesorID == search.ProfesorID.Value);
                }
                if (search.OdjeljenjeID.HasValue)
                {
                    query = query.Where(x => x.GodisnjiPlanProgram.OdjeljenjeID == search.OdjeljenjeID.Value);
                }
                if (search.CasoviID.HasValue)
                {
                    query = query.Where(x => x.CasoviID == search.CasoviID.Value);
                }
                if (search.IsOdrzan.HasValue)
                {
                    query = query.Where(x => x.IsOdrzan == search.IsOdrzan.Value);
                }
            }

            return base.AddFilter(query, search);
        }
        public override async Task<PagedResult<Model.Models.Casovi>> Get(CasoviSearchObject search = null)
        {
            var query = _context.Casovi
                .Include(x => x.GodisnjiPlanProgram)
                .AsQueryable();

            query = AddFilter(query, search);

            var totalCount = await query.CountAsync();
            if (search.Page.HasValue && search.PageSize.HasValue)
            {
                query = query.Skip((search.Page.Value - 1) * search.PageSize.Value)
                             .Take(search.PageSize.Value);
            }

            var list = await query.ToListAsync();

            return new PagedResult<Model.Models.Casovi>
            {
                Result = _mapper.Map<List<Model.Models.Casovi>>(list),
                Count = totalCount
            };
        }

        public override async Task<Model.Models.Casovi> Insert(CasoviInsertRequest request)
        {
            var godisnjiPlanProgram = await _context.GodisnjiPlanProgram
                .Include(g => g.Casovi)
                .FirstOrDefaultAsync(g => g.GodisnjiPlanProgramID == request.GodisnjiPlanProgramID);

            if (godisnjiPlanProgram == null)
            {
                throw new UserException("Godisnji Plan Program not found.");
            }

            if (godisnjiPlanProgram.Casovi.Count >= godisnjiPlanProgram.brojCasova)
            {
                throw new UserException($"Ne možete imati više od {godisnjiPlanProgram.brojCasova} časova za ovaj godišnji plan i program.");
            }

            return await base.Insert(request);
        }

        public override async Task<Model.Models.Casovi> Update(int id, CasoviUpdateRequest request)
        {
            var godisnjiPlanProgram = await _context.GodisnjiPlanProgram
                .Include(g => g.Casovi)
                .FirstOrDefaultAsync(g => g.GodisnjiPlanProgramID == request.GodisnjiPlanProgramID);

            if (godisnjiPlanProgram == null)
            {
                throw new UserException("Godisnji Plan Program not found.");
            }

            var currentCasoviCount = godisnjiPlanProgram.Casovi.Count(x => x.CasoviID != id);

            if (currentCasoviCount >= godisnjiPlanProgram.brojCasova)
            {
                throw new UserException($"Cannot update more than {godisnjiPlanProgram.brojCasova} Casovi for this Godisnji Plan Program.");
            }

            return await base.Update(id, request);
        }

        public override async Task<Model.Models.Casovi> Delete(int id, CasoviDeleteRequest deleteRequest)
        {
            var casovi = await _context.Casovi.FindAsync(id);

            if (casovi == null)
            {
                throw new UserException("Casovi not found.");
            }

            if (casovi.IsOdrzan)
            {
                throw new UserException("Ne mozete obrisati casove koji su odrzani.");
            }

            return await base.Delete(id, deleteRequest);
        }

    }
}
