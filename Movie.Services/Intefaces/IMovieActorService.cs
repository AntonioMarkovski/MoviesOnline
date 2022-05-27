using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Services.Interfaces
{
    public interface IMovieActorService
    {
        void AddMovieActor(Actor actor, Movies movie);

        void AddMovieActorsList(List<MovieActor> movieActors);

        void DeleteMovieActor(MovieActor movieActor);
    }
}