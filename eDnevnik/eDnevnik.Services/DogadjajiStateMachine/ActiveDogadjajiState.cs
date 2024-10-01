using AutoMapper;
using eDnevnik.Model.Models;
using eDnevnik.Services.DogadjajiStateMachine;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.DogadjajiStateMachine
{
    public class ActiveDogadjajiState : BaseStateDogadjaji
    {
        public ActiveDogadjajiState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<Dogadjaji> Hide(int id)
        {
            var set = _context.Set<Database.Dogadjaji>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();
            return _mapper.Map<Dogadjaji>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Hide");

            return list;
        }
    }
}
