using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;

namespace InsightHive.PersistenceDemo
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly Dictionary<Type, IList> demoData = new Dictionary<Type, IList>();

        public CategoryRepository()
        {
            PopulateDemoData();
        }

        private void PopulateDemoData()
        {
            demoData[typeof(Category)] = new List<Category>
            {
                new Category { Id = 1, Name = "Restaurants" },
                new Category { Id = 2, Name = "Repairs" }
            };

            demoData[typeof(SubCategory)] = new List<SubCategory>
            {
                new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Pizza", CategoryId = 2}
            };
        }

        public Task<bool> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> SelectAllAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> SelectOneAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdWithSubCategoriesAsync(int id)
        {
            var category = ((List<Category>)demoData[typeof(Category)]).FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                var subCategories = ((List<SubCategory>)demoData[typeof(SubCategory)]).Where(s => s.CategoryId == id).ToList();
                category.SubCategories = subCategories;
            }

            return await Task.FromResult(category);
        }

        public async Task<Category> GetByNameWithSubCategoriesAsync(string name)
        {
            var category = ((List<Category>)demoData[typeof(Category)]).FirstOrDefault(c => c.Name == name);

            if (category != null)
            {
                var subCategories = ((List<SubCategory>)demoData[typeof(SubCategory)]).Where(s => s.CategoryId == category.Id).ToList();
                category.SubCategories = subCategories;
            }

            return await Task.FromResult(category);
        }

        public async Task<List<Category>> GetAllCategoriesWithSubCategoriesAsync()
        {
            var categories = ((List<Category>)demoData[typeof(Category)]);

            foreach (var category in categories)
            {
                var subCategories = ((List<SubCategory>)demoData[typeof(SubCategory)])
                    .Where(s => s.CategoryId == category.Id)
                    .Select(s => new SubCategory{ Id = s.Id, Name = s.Name })
                    .ToList();

                category.SubCategories = (List<SubCategory>)subCategories;
            }
            return await Task.FromResult(categories);
        }

    }
        
}
