using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movie.Services.Interfaces
{
    public interface IMoviesServices
    {
        void Add(Movies movie);
        void Edit(Movies movie);
        void Edit(int id);
        void Delete(int movieId);
        Movies GetMovieById(int id);
        IEnumerable<Movies> SearchMovies(string searchString);

        IEnumerable<Movies> GetAllMovies();

        (MultiSelectList Categories,
        List<SelectListItem> Publishers,
        List<SelectListItem> Directors,
        MultiSelectList Actors)
            FillDropdowns(
        IEnumerable<Category> categories,
        IEnumerable<Publisher> publishers,
        IEnumerable<Director> directors,
        IEnumerable<Actor> actors);
    }
}