using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface IActorRepository
    {
        void AddActor(Actor actor);
        void EditActor(Actor actor);
        void DeleteActor(int actorId);
        Actor GetActorById(int id);
        IEnumerable<Actor> GetAllActors();
    }
}