using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.PersistenceDemo
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        Dictionary<Type, IList> demoData = new Dictionary<Type, IList>();


        public BaseRepository()
        {

            // Dummy data for Category
            demoData[typeof(Category)] = new List<Category>
            {
                new Category { Id = 1, Name = "Restaurants" },
                new Category { Id = 2, Name = "Repairs" }
            };

            // Dummy data for SubCategory
            demoData[typeof(SubCategory)] = new List<SubCategory>
            {
                new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Pizza", CategoryId = 1 }
            };

            // Dummy data for Business
            demoData[typeof(Business)] = new List<Business>
            {
                new Business { Id = 1, Name = "Burger Joint", Description = "Best burgers in town", Logo = "burger.png", SubCategoryId = 1 },
                new Business { Id = 2, Name = "Pizza Place", Description = "Authentic Italian pizzas", Logo = "pizza.png", SubCategoryId = 2 }
            };

            // Dummy data for Owner
            demoData[typeof(Owner)] = new List<Owner>
            {
                new Owner { Id = 1, BusinessId = 1 },
                new Owner { Id = 2, BusinessId = 2 }
            };

        }
        public Task<bool> AddAsync(T entity)
        {
            demoData[typeof(T)].Add(entity);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(T entity)
        {
            demoData[typeof(T)].Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T> GetByIdAsync(int id)
        {
            var list = (List<T>)demoData[typeof(T)];
            Func<dynamic, bool> predicate = (list) => list.Id == id;
            return Task.FromResult(list.FirstOrDefault(predicate));
        }
        public async Task<T> GetByNameAsync(string name)
        {
            var list = (List<T>)demoData[typeof(T)];
            Func<dynamic, bool> predicate = (entity) => entity.Name == name;
            var result = list.FirstOrDefault(predicate);
            return await Task.FromResult<T>(result);
        }



        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            return Task.FromResult((IReadOnlyList<T>)demoData[typeof(T)]);
        }

        public Task<T> SelectAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> SelectOneAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public async Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            var list = (List<SubCategory>)demoData[typeof(SubCategory)];
            return await Task.FromResult(list.Where(s => s.CategoryId == categoryId).ToList());
        }

    }
}
