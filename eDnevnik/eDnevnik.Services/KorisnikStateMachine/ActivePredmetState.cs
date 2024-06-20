using AutoMapper;
using eDnevnik.Model.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.KorisnikStateMachine
{
    public class ActivePredmetState : BaseState
    {
        public ActivePredmetState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<Predmet> Hide(int id)
        {
            var set = _context.Set<Database.Predmet>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();
            return _mapper.Map<Predmet>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Hide");

            return list;
        }
    }
}
