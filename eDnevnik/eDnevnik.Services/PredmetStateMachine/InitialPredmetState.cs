using AutoMapper;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.KorisnikStateMachine
{
    public class InitialPredmetState : BaseState
    {
        public InitialPredmetState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }
        public override async Task<Predmet> Insert(PredmetInsertRequest request)
        {
            var set = _context.Set<Database.Predmet>();

            var entity = _mapper.Map<Database.Predmet>(request);
            entity.StateMachine = "draft";

            set.Add(entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Predmet>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("insert");

            return list;
        }

    }
}
