using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Repository
{
    public class MovieCategoryRepository : IMovieCategoryRepository
    {
        private readonly DataContext _context;

        public MovieCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddMovieCategoriesList(List<MovieCategory> movieCategories)
        {
            _context.MovieCategories.AddRange(movieCategories);
            _context.SaveChanges();
        }

        public void AddMovieCategory(Category category, Movies movie)
        {
            var movieCategory = new MovieCategory { MovieID = movie.Id, CategoryID = category.ID };
            _context.MovieCategories.Add(movieCategory);
            _context.SaveChanges();
        }

        public void DeleteMovieCategory(MovieCategory movieCategory)
        {
            _context.MovieCategories.Remove(movieCategory);
            _context.SaveChanges();
        }
    }
}
