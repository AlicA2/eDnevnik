using AutoMapper;
using eDnevnik.Model;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class PredmetService : BaseCRUDService<Model.Models.Predmet, Database.Predmet, PredmetSearchObject, PredmetInsertRequest, PredmetUpdateRequest, PredmetDeleteRequest>, IPredmetService
    {
        public BaseState _baseState { get; set; }
        public PredmetService(BaseState baseState, eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;
        }
        public override IQueryable<Predmet> AddFilter(IQueryable<Predmet> query, PredmetSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
                }
                if (!string.IsNullOrWhiteSpace(search.FTS))
                {
                    query = query.Where(x => x.Naziv.Contains(search.Naziv));
                }
                if (search.SkolaID.HasValue)
                {
                    query = query.Where(x => x.SkolaID == search.SkolaID.Value);
                }
                if (search.PredmetID.HasValue)
                {
                    query = query.Where(x => x.PredmetID == search.PredmetID.Value);
                }
            }
            return base.AddFilter(query, search);
        }

        public override IQueryable<Predmet> AddInclude(IQueryable<Predmet> query, PredmetSearchObject? search = null)
        {
            if (search?.isOcjeneIncluded == true)
            {
                query = query.Include(p => p.Ocjene);
            }
            return base.AddInclude(query, search);
        }

        public override async Task<Model.Models.Predmet> Delete(int id, PredmetDeleteRequest delete)
        {
            var entity = await _context.Predmeti.FindAsync(id);

            if (entity == null)
            {
                throw new UserException("Predmet not found.");
            }

            try
            {
                _context.Predmeti.Remove(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<Model.Models.Predmet>(entity);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
                {
                    throw new UserException("Ne mozete obrisati Predmet zato sto je povezan sa jos jednim zapisom u sistemu.");
                }
                else
                {
                    throw new UserException("An unexpected error occurred while deleting the Predmet.");
                }
            }
        }

        public override async Task<Model.Models.Predmet> Insert(PredmetInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");
            return await state.Insert(insert);
        }

        public override async Task<Model.Models.Predmet> Update(int id, PredmetUpdateRequest update)
        {
            var entity = await _context.Predmeti.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Update(id, update);
        }

        public async Task<Model.Models.Predmet> Activate(int id)
        {
            var entity = await _context.Predmeti.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Activate(id);
        }
        public async Task<Model.Models.Predmet> Hide(int id)
        {
            var entity = await _context.Predmeti.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Predmeti.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");
            return await state.AllowedActions();
        }

        public async Task<bool> AddOcjena(int predmetID, OcjeneInsertRequest request)
        {
            var predmet = await _context.Predmeti
                .Include(p => p.Ocjene)
                .FirstOrDefaultAsync(p => p.PredmetID == predmetID);

            if (predmet == null)
            {
                throw new ArgumentException("Predmet not found.");
            }

            var ocjena = new Ocjene
            {
                KorisnikID = request.KorisnikID,
                PredmetID = predmetID,
                VrijednostOcjene = request.VrijednostOcjene,
                Datum = request.Datum
            };

            if (ocjena.VrijednostOcjene < 1 || ocjena.VrijednostOcjene > 5)
            {
                throw new UserException("Ocjena koju ste unjeli nije validna! Možete davati ocjene samo od 1 do 5");
            }

            predmet.Ocjene.Add(ocjena);

            await _context.SaveChangesAsync();

            var zakljucnaOcjenaValue = await CalculateZakljucnaOcjena(predmetID, request.KorisnikID);

            var existingZakljucnaOcjena = await _context.ZakljucnaOcjena
                .FirstOrDefaultAsync(z => z.PredmetID == predmetID && z.KorisnikID == request.KorisnikID);

            if (existingZakljucnaOcjena != null)
            {
                existingZakljucnaOcjena.vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0;
                _context.ZakljucnaOcjena.Update(existingZakljucnaOcjena);
            }
            else
            {
                var zakljucnaOcjena = new ZakljucnaOcjena
                {
                    PredmetID = predmetID,
                    KorisnikID = request.KorisnikID,
                    vrijednostZakljucneOcjene = zakljucnaOcjenaValue ?? 0
                };

                await _context.ZakljucnaOcjena.AddAsync(zakljucnaOcjena);
            }

            await _context.SaveChangesAsync();

            return true;
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
