//using AutoMapper;
//using eDnevnik.Model.Models;
//using eDnevnik.Model.Requests;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eDnevnik.Services.KorisnikStateMachine
//{
//    public class InitialKorisnikState : BaseState
//    {
//        public InitialKorisnikState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider,context, mapper)
//        {
//        }

//        public override async Task<Korisnik> Insert(KorisniciInsertRequest request)
//        {
//            var set = _context.Set<Database.Korisnik>();

//            var entity = _mapper.Map<Database.Korisnik>(request);
//            entity.StateMachine = "draft";

//            set.Add(entity);

//            await _context.SaveChangesAsync();
//            return _mapper.Map<Model.Models.Korisnik>(entity);
//        }
//    }
//}
