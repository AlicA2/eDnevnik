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
                if (search.KorisnikID.HasValue)
                {
                    query = query.Where(x => x.KorisnikID == search.KorisnikID.Value);
                }
            }
            return base.AddFilter(query, search);
        }

        public override async Task<Model.Models.Ocjene> Update(int id, OcjeneUpdateRequest update)
        {
            var ocjena = await _context.Ocjene.FindAsync(id);

            if (ocjena == null)
            {
                throw new ArgumentException("Ocjena not found.");
            }

            _mapper.Map(update, ocjena);

            _context.Ocjene.Update(ocjena);

            var predmet = await _context.Predmeti
                .Include(p => p.Ocjene)
                .FirstOrDefaultAsync(p => p.PredmetID == ocjena.PredmetID);

            if (predmet != null)
            {
                predmet.ZakljucnaOcjena = await CalculateZakljucnaOcjena(ocjena.PredmetID, ocjena.KorisnikID);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Models.Ocjene>(ocjena);
        }


        public async Task<decimal?> CalculateZakljucnaOcjena(int predmetID, int korisnikID)
        {
            var predmet = await _context.Predmeti
                .Include(p => p.Ocjene)
                .FirstOrDefaultAsync(p => p.PredmetID == predmetID);

            if (predmet == null || !predmet.Ocjene.Any())
            {
                return null;
            }

            var relevantOcjene = predmet.Ocjene
                .Where(o => o.KorisnikID == korisnikID)
                .Select(o => o.VrijednostOcjene)
                .ToList();

            if (!relevantOcjene.Any())
            {
                return null;
            }

            decimal sum = relevantOcjene.Sum();
            int count = relevantOcjene.Count;

            decimal average = count > 0 ? sum / count : 0;

            return Math.Round(average, 2);
        }

    }
}
