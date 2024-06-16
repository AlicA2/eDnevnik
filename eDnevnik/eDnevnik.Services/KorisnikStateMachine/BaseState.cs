using AutoMapper;
using eDnevnik.Model.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.KorisnikStateMachine
{
    public class BaseState
    {
        protected eDnevnikDBContext _context;
        public IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider,eDnevnikDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public virtual Task<Model.Models.Korisnik> Insert(KorisniciInsertRequest request)
        {
            throw new Exception("Not allowed");
        }
        public virtual Task<Model.Models.Korisnik> Update(int id, KorisniciUpdateRequest request)
        {
            throw new Exception("Not allowed");
        }
        public virtual Task<Model.Models.Korisnik> Activate(int id)
        {
            throw new Exception("Not allowed");
        }
        public virtual Task<Model.Models.Korisnik> Hide(int id)
        {
            throw new Exception("Not allowed");
        }
        public virtual Task<Model.Models.Korisnik> Delete(int id)
        {
            throw new Exception("Not allowed");
        }

        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return _serviceProvider.GetService<InitialKorisnikState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftKorisnikState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActiveKorisnikState>();
                    break;
                        
                default:
                    throw new Exception("Not allowed");
            }
        }
    }
}
