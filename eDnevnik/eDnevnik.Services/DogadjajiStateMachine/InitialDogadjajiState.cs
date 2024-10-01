using AutoMapper;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Services.DogadjajiStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.DogadjajiStateMachine
{
    public class InitialDogadjajiState : BaseStateDogadjaji
    {
        public InitialDogadjajiState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }
        public override async Task<Dogadjaji> Insert(DogadjajiInsertRequest request)
        {
            var set = _context.Set<Database.Dogadjaji>();

            var entity = _mapper.Map<Database.Dogadjaji>(request);
            entity.StateMachine = "draft";

            set.Add(entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Dogadjaji>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("insert");

            return list;
        }

    }
}
