using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InsightHive.PersistenceDemo
{
    public class SubCategoryRepo : ISubCategoryRepo
    {
        private readonly Dictionary<Type, IList> demoData = new Dictionary<Type, IList>();

        public SubCategoryRepo()
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
                new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 ,Category=new Category { Id = 1, Name = "Restaurants"} },
                new SubCategory { Id = 2, Name = "Pizza", CategoryId = 1 ,Category=new Category { Id = 1, Name = "Restaurants"} }
            };
        }

        public Task<bool> AddAsync(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            var list = (List<SubCategory>)demoData[typeof(SubCategory)];
            return await Task.FromResult(list.Where(s => s.CategoryId == categoryId).ToList());
        }

        public Task<SubCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetByIdWithSubCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<SubCategory>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> SelectAllAsync(Expression<Func<SubCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<SubCategory>> SelectOneAsync(Expression<Func<SubCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SubCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
