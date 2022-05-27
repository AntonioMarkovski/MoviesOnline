using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Services.Interfaces

{
    public interface IActorServices
    {
        void Add(Actor actor);
        void Edit(Actor actor);
        void Delete(int actorId);
        Actor GetActorById(int id);
        IEnumerable<Actor> GetAllActors();

        string GetAllActorNames(int[] actorIds);
    }
}