namespace Movie.Repository.Interfaces
{
    using Movie.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IMovieCategoryRepository
    {
        void AddMovieCategory(Category category, Movies movie);

        void AddMovieCategoriesList(List<MovieCategory> movieCategories);

        void DeleteMovieCategory(MovieCategory movieCategory);
    }
}