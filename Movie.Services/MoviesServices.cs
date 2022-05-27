using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesServices(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public void Add(Movies movie)
        {
            _moviesRepository.AddMovies(movie);
        }

        public void Delete(int movieId)
        {
            _moviesRepository.DeleteMovies(movieId);

        }

        public void Edit(Movies movie)
        {
            _moviesRepository.EditMovies(movie);
        }

        public void Edit(int id)
        {
            _moviesRepository.EditMovies(id);
        }

        public IEnumerable<Movies> GetAllMovies()
        {
            var result = _moviesRepository.GetAllMovies();
            return result;
        }

        public Movies GetMovieById(int id)
        {
            var result = _moviesRepository.GetMoviesById(id);
            return result;
        }

        public IEnumerable<Movies> SearchMovies(string searchString)
        {
            var result = _moviesRepository.SearchMovies(searchString);
            return result;
        }



        #region Helper Functions

        public (MultiSelectList Categories, List<SelectListItem> Publishers, List<SelectListItem> Directors, MultiSelectList Actors)
        FillDropdowns(IEnumerable<Category> categories, IEnumerable<Publisher> publishers, IEnumerable<Director> directors, IEnumerable<Actor> actors)
        {
            MultiSelectList Categories = new MultiSelectList(categories, "ID", "Name");

            List<SelectListItem> Publishers = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text= "Select producer...",Selected=true}
            };

            List<SelectListItem> Directors = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text= "Select director...",Selected=true}
            };

            MultiSelectList Actors = new MultiSelectList(actors, "Id", "Name");

            foreach (var publisher in publishers)
            {
                Publishers.Add(new SelectListItem { Value = publisher.Id.ToString(), Text = publisher.Name });
            }

            foreach (var director in directors)
            {
                Directors.Add(new SelectListItem { Value = director.Id.ToString(), Text = director.Name });
            }

            return (Categories, Publishers, Directors, Actors);
        }

        #endregion


    }
}
