using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.DogadjajiStateMachine;
using eDnevnik.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class DogadjajiService : BaseCRUDService<Model.Models.Dogadjaji, Database.Dogadjaji, DogadjajiSearchObject, DogadjajiInsertRequest, DogadjajiUpdateRequest, DogadjajiDeleteRequest>, IDogadjajiService
    {
        public BaseStateDogadjaji _baseState { get; set; }

        public DogadjajiService(BaseStateDogadjaji baseState, eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;

        }

        public override async Task<Model.Models.Dogadjaji> Insert(DogadjajiInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");
            return await state.Insert(insert);
        }

        public override async Task<Model.Models.Dogadjaji> Update(int id, DogadjajiUpdateRequest update)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Update(id, update);
        }

        public async Task<Model.Models.Dogadjaji> Activate(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Activate(id);
        }
        public async Task<Model.Models.Dogadjaji> Hide(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");
            return await state.AllowedActions();
        }

        public override IQueryable<Dogadjaji> AddFilter(IQueryable<Dogadjaji> query, DogadjajiSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.NazivDogadjaja))
                {
                    query = query.Where(x => x.NazivDogadjaja.StartsWith(search.NazivDogadjaja));
                }
                if (!string.IsNullOrWhiteSpace(search.OpisDogadjaja))
                {
                    query = query.Where(x => x.OpisDogadjaja.Contains(search.OpisDogadjaja));
                }
                if (search.DogadjajId.HasValue)
                {
                    query = query.Where(x => x.DogadjajId == search.DogadjajId.Value);
                }
            }

            return base.AddFilter(query, search);
        }
    }
}
