using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface IMovieActorRepository
    {
        void AddMovieActor(Actor actor, Movies movie);

        void AddMovieActorsList(List<MovieActor> movieActors);

        void DeleteMovieActor(MovieActor movieActor);
    }
}