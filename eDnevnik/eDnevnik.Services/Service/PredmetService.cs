using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.IServices;
using eDnevnik.Services.KorisnikStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class PredmetService : BaseCRUDService<Model.Models.Predmet, Database.Predmet, PredmetSearchObject, PredmetInsertRequest, PredmetUpdateRequest>, IPredmetService
    {
        public BaseState _baseState { get; set; }
        public PredmetService(BaseState baseState, eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState=baseState;
        }
        public override IQueryable<Predmet> AddFilter(IQueryable<Predmet> query, PredmetSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x=>x.Naziv.Contains(search.FTS) || x.Naziv.Contains(search.FTS));
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }

            return filteredQuery;
        }

        //public override IQueryable<Korisnik> AddInclude(IQueryable<Korisnik> query, PredmetSearchObject? search = null)
        //{
        //    if (search?.isUlogeIncluded == true)
        //    {
        //        query = query.Include("KorisniciUloge.Uloga");
        //    }
        //    return base.AddInclude(query, search);
        //}

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
    }
}
