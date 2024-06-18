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

    }
}
