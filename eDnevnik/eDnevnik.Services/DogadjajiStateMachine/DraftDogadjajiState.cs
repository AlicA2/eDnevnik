using AutoMapper;
using EasyNetQ;
using eDnevnik.Model;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Services.DogadjajiStateMachine;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.DogadjajiStateMachine
{
    public class DraftDogadjajiState : BaseStateDogadjaji
    {
        public DraftDogadjajiState(IServiceProvider serviceProvider, eDnevnikDBContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }


        public override async Task<Dogadjaji> Update(int id, DogadjajiUpdateRequest request)
        {
            var set = _context.Set<Database.Dogadjaji>();

            var entity = await set.FindAsync(id);
            entity.StateMachine = "draft";


            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Dogadjaji>(entity);
        }

        public override async Task<Dogadjaji> Activate(int id)
        {

            var set = _context.Set<Database.Dogadjaji>();

            var entity = await set.FindAsync(id);
            entity.StateMachine = "active";


            await _context.SaveChangesAsync();

            var mappedEntity = _mapper.Map<Model.Models.Dogadjaji>(entity);

            using var bus = RabbitHutch.CreateBus("host=localhost");
            bus.PubSub.Publish(mappedEntity);
            return mappedEntity;
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
