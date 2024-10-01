using AutoMapper;
using eDnevnik.Model;
using eDnevnik.Model.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Services.DogadjajiStateMachine
{
    public class BaseStateDogadjaji
    {
        protected eDnevnikDBContext _context;
        public IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }

        public BaseStateDogadjaji(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual Task<Model.Models.Dogadjaji> Insert(DogadjajiInsertRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Models.Dogadjaji> Update(int id, DogadjajiUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Models.Dogadjaji> Activate(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Models.Dogadjaji> Hide(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual Task<Model.Models.Dogadjaji> Delete(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseStateDogadjaji CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                case null:
                    return _serviceProvider.GetService<InitialDogadjajiState>();
                case "draft":
                    return _serviceProvider.GetService<DraftDogadjajiState>();
                case "active":
                    return _serviceProvider.GetService<ActiveDogadjajiState>();
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
