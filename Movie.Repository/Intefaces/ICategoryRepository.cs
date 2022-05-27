using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
    }
}