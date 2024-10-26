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

            await _context.SaveChangesAsync();

            var zakljucnaOcjenaValue = await CalculateZakljucnaOcjena(ocjena.PredmetID, ocjena.KorisnikID);

            var existingZakljucnaOcjena = await _context.ZakljucnaOcjena
                .FirstOrDefaultAsync(z => z.PredmetID == ocjena.PredmetID && z.KorisnikID == ocjena.KorisnikID);

            if (existingZakljucnaOcjena != null)
            {
                existingZakljucnaOcjena.vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0;
                _context.ZakljucnaOcjena.Update(existingZakljucnaOcjena);
            }
            else
            {
                var zakljucnaOcjena = new ZakljucnaOcjena
                {
                    PredmetID = ocjena.PredmetID,
                    KorisnikID = ocjena.KorisnikID,
                    vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0
                };

                await _context.ZakljucnaOcjena.AddAsync(zakljucnaOcjena);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Models.Ocjene>(ocjena);
        }

        public async Task AddFinalGradesForExistingData()
        {
            var predmeti = await _context.Predmeti
                .Include(p => p.Ocjene)
                .ToListAsync();

            foreach (var predmet in predmeti)
            {
                var ocjenePoKorisniku = predmet.Ocjene
                    .GroupBy(o => o.KorisnikID)
                    .ToList();

                foreach (var group in ocjenePoKorisniku)
                {
                    int korisnikID = group.Key;

                    var zakljucnaOcjenaValue = await CalculateZakljucnaOcjena(predmet.PredmetID, korisnikID);

                    var existingZakljucnaOcjena = await _context.ZakljucnaOcjena
                        .FirstOrDefaultAsync(z => z.PredmetID == predmet.PredmetID && z.KorisnikID == korisnikID);

                    if (existingZakljucnaOcjena == null)
                    {
                        var zakljucnaOcjena = new ZakljucnaOcjena
                        {
                            PredmetID = predmet.PredmetID,
                            KorisnikID = korisnikID,
                            vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0
                        };

                        await _context.ZakljucnaOcjena.AddAsync(zakljucnaOcjena);
                    }
                    else
                    {
                        existingZakljucnaOcjena.vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0;
                        _context.ZakljucnaOcjena.Update(existingZakljucnaOcjena);
                    }
                }
            }

            await _context.SaveChangesAsync();
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

        public override async Task<Model.Models.Ocjene> Insert(OcjeneInsertRequest insert)
        {
            var ocjenaEntity = _mapper.Map<Database.Ocjene>(insert);

            await _context.Ocjene.AddAsync(ocjenaEntity);
            await _context.SaveChangesAsync();

            var zakljucnaOcjenaValue = await CalculateZakljucnaOcjena(ocjenaEntity.PredmetID, ocjenaEntity.KorisnikID);

            var existingZakljucnaOcjena = await _context.ZakljucnaOcjena
                .FirstOrDefaultAsync(z => z.PredmetID == ocjenaEntity.PredmetID && z.KorisnikID == ocjenaEntity.KorisnikID);

            if (existingZakljucnaOcjena != null)
            {
                existingZakljucnaOcjena.vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0;
                _context.ZakljucnaOcjena.Update(existingZakljucnaOcjena);
            }
            else
            {
                var zakljucnaOcjena = new ZakljucnaOcjena
                {
                    PredmetID = ocjenaEntity.PredmetID,
                    KorisnikID = ocjenaEntity.KorisnikID,
                    vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0
                };

                await _context.ZakljucnaOcjena.AddAsync(zakljucnaOcjena);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Models.Ocjene>(ocjenaEntity);
        }


    }
}
