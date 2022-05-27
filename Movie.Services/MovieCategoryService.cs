using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Services
{
    public class MovieCategoryService : IMovieCategoryService
    {
        private readonly IMovieCategoryRepository _movieCategoryRepository;

        public MovieCategoryService(IMovieCategoryRepository movieCategoryRepository)
        {
            _movieCategoryRepository = movieCategoryRepository;
        }

        public void AddMovieCategory(Category category, Movies movie)
        {
            _movieCategoryRepository.AddMovieCategory(category, movie);
        }

        public void AddMovieCategoriesList(List<MovieCategory> movieCategories)
        {
            _movieCategoryRepository.AddMovieCategoriesList(movieCategories);
        }

        public void DeleteMovieCategory(MovieCategory movieCategory)
        {
            _movieCategoryRepository.DeleteMovieCategory(movieCategory);
        }
    }
}
