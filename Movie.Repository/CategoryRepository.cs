using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddCategory(Category category)
        {
            _dataContext.Category.Add(category);
            _dataContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = GetCategoryById(categoryId);
            _dataContext.Category.Remove(category);
            _dataContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _dataContext.Category.Update(category);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = _dataContext.Category.AsEnumerable();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _dataContext.Category.FirstOrDefault(x => x.ID == id);
            return result;
        }
    }
}
