using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Services
{
    public class MovieActorService : IMovieActorService
    {
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorService(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        public void AddMovieActor(Actor actor, Movies movie)
        {
            _movieActorRepository.AddMovieActor(actor, movie);
        }

        public void AddMovieActorsList(List<MovieActor> movieActors)
        {
            _movieActorRepository.AddMovieActorsList(movieActors);
        }

        public void DeleteMovieActor(MovieActor movieActor)
        {
            _movieActorRepository.DeleteMovieActor(movieActor);
        }
    }
}
