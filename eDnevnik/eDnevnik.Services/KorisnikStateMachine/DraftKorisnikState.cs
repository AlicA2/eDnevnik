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
    public class DraftKorisnikState : BaseState
    {
        public DraftKorisnikState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider,context, mapper)
        {
        }

        public override async Task<Korisnik> Update(int id, KorisniciUpdateRequest request)
        {
            var set = _context.Set<Database.Korisnik>();

            var entity = await set.FindAsync(id);
            entity.StateMachine = "draft";

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Korisnik>(entity);
        }
    }
}
