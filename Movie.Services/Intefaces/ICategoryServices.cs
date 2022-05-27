using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Services.Interfaces
{
    public interface ICategoryServices
    {
        void Add(Category category);
        void Edit(Category category);
        void Delete(int categoryId);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();

        string GetAllCategories(int[] categoriesIds);

    }
}