namespace Movie.Services.Interfaces
{
    using Movie.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMovieCategoryService
    {
        void AddMovieCategory(Category category, Movies movie);

        void AddMovieCategoriesList(List<MovieCategory> movieCategories);

        void DeleteMovieCategory(MovieCategory movieCategory);
    }
}