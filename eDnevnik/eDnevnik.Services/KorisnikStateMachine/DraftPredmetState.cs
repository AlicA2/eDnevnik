using AutoMapper;
using eDnevnik.Model;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.KorisnikStateMachine
{
    public class DraftPredmetState : BaseState
    {
        public DraftPredmetState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }
        public override async Task<Predmet>Update(int id, PredmetUpdateRequest request)
        {
            var set = _context.Set<Database.Predmet>();

            var entity = await set.FindAsync(id);
            entity.StateMachine = "draft";

            foreach (var ocjena in entity.Ocjene)
            {
                if(ocjena.Ocjena<0 || ocjena.Ocjena > 5)
                {
                    throw new UserException("Ocjena nije validna");
                }
            }

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Predmet>(entity);
        }

        public override async Task<Predmet> Activate(int id)
        {

            var set = _context.Set<Database.Predmet>();

            var entity = await set.FindAsync(id);
            entity.StateMachine = "active";


            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Predmet>(entity);
        }
        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Update");
            list.Add("Activate");

            return list;
        }
    }
}
