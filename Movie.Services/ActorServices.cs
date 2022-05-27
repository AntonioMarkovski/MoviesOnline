using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class ActorServices : IActorServices
    {
        private readonly IActorRepository _actorRepository;

        public ActorServices(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public void Add(Actor actor)
        {
            _actorRepository.AddActor(actor);
        }

        public void Delete(int actorId)
        {
            _actorRepository.DeleteActor(actorId);
        }

        public void Edit(Actor actor)
        {
            _actorRepository.EditActor(actor);

        }

        public IEnumerable<Actor> GetAllActors()
        {
            var result = _actorRepository.GetAllActors();
            return result;
        }

        public Actor GetActorById(int id)
        {
            var result = _actorRepository.GetActorById(id);
            return result;
        }
        public string GetAllActorNames(int[] actorIds)
        {
            string actorNames = "";

            if (actorIds.Length > 0)
            {
                foreach (var actorId in actorIds)
                {
                    var lastItem = actorIds.Last();
                    var getActor = _actorRepository.GetActorById(actorId);
                    actorNames += actorId.Equals(lastItem) ? getActor.Name : getActor.Name + ",";
                }
            }
            return actorNames;
        }
    }
}
