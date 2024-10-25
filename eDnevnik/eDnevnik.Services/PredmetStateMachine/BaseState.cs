using AutoMapper;
using eDnevnik.Model;
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
        public virtual Task<Model.Models.Predmet> Insert(PredmetInsertRequest request)
        {
            throw new UserException("Not allowed");
        }
        public virtual Task<Model.Models.Predmet> Update(int id, PredmetUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }
        public virtual Task<Model.Models.Predmet> Activate(int id)
        {
            throw new UserException("Not allowed");
        }
        public virtual Task<Model.Models.Predmet> Hide(int id)
        {
            throw new UserException("Not allowed");
        }
        public virtual Task<Model.Models.Predmet> Delete(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    case null:
                    return _serviceProvider.GetService<InitialPredmetState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftPredmetState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActivePredmetState>();
                    break;
                        
                default:
                    throw new Exception("Not allowed");
            }
        }

        public virtual async Task<List<string>> AllowedActions()
        {
            return new List<string>();
        }
    }
}
