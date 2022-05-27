using Microsoft.Extensions.Logging;
using Movie.Data;
using Movie.Entities;
using Movie.Entities.Logger;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Movie.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<MoviesRepository> _logger;


        public MoviesRepository(DataContext dataContext,
            ILogger<MoviesRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;

        }
        public void AddMovies(Movies movies)
        {

            try
            {
                _dataContext.Movies.Add(movies);
                _dataContext.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.MovieCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error because of exception" + ex);
                throw;
            }
        }
        public void DeleteMovies(int moviesId)
        {
            try
            {
                Movies movies = GetMoviesById(moviesId);
                _dataContext.Movies.Remove(movies);
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error because of exception" + ex);
                throw;
            }

        }

        public void EditMovies(Movies movies)
        {
            _dataContext.Movies.Update(movies);
            _dataContext.SaveChanges();
        }

        public void EditMovies(int id)
        {
            var movies = GetMoviesById(id);
            _dataContext.Movies.Update(movies);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Movies> GetAllMovies()
        {
            var result = _dataContext.Movies.AsEnumerable();
            return result;
        }

        public Movies GetMoviesById(int id)
        {
            var result = _dataContext.Movies.FirstOrDefault(x => x.Id == id);
            return result;
        }
        public IEnumerable<Movies> SearchMovies(string searchString)
        {
            var movies = _dataContext.Movies.AsEnumerable();
            var actor = _dataContext.Movies.AsEnumerable();
            var category = _dataContext.Movies.AsEnumerable();
            //var noResult = _dataContext.Movies.AsEnumerable();

            if (String.IsNullOrEmpty(searchString))
            {
                var empty = searchString;
                movies = _dataContext.Movies.AsEnumerable();
                return movies;
            }

            var search = searchString.ToLower();

            if (!string.IsNullOrEmpty(search))
            {
                movies = movies.Where(x => x.Title.ToLower().Contains(search));

                if (movies == null || !movies.Any())
                {
                    actor = actor.Where(x => x.ActorNames.ToLower().Contains(search));

                    if (actor == null || !actor.Any())
                    {
                        category = category.Where(x => x.Categories.ToLower().Contains(search));
                        if (category == null || !category.Any())
                        {
                            //return noResult;
                            return movies;
                        }
                        return category;
                    }
                    return actor;
                }
            }
            return movies;
        }
    }
}
