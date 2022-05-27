using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface IMoviesRepository
    {
        void AddMovies(Movies Movies);
        void EditMovies(Movies Movies);
        void EditMovies(int id);
        void DeleteMovies(int MoviesId);
        Movies GetMoviesById(int id);
        IEnumerable<Movies> GetAllMovies();
        IEnumerable<Movies> SearchMovies(string searchString);
    }
}