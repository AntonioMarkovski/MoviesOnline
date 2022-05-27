using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void Delete(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public void Edit(Category category)
        {
            _categoryRepository.EditCategory(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = _categoryRepository.GetAllCategories();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _categoryRepository.GetCategoryById(id);
            return result;
        }
        public string GetAllCategories(int[] categoriesIds)
        {
            string categories = "";

            if (categoriesIds.Length > 0)
            {
                foreach (var categoryId in categoriesIds)
                {
                    var lastItem = categoriesIds.Last();
                    var getCategory = _categoryRepository.GetCategoryById(categoryId);
                    categories += categoryId.Equals(lastItem) ? getCategory.Name : getCategory.Name + ", ";
                }
            }

            return categories;
        }
    }
}
