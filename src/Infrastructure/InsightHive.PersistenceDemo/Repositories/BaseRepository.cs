using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace InsightHive.PersistenceDemo.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        Dictionary<Type, IList> demoData = new Dictionary<Type, IList>();


        public BaseRepository()
        {
            demoData[typeof(Category)] = new List<Category> { new Category { Id = 1, Name = "Restaurants" }, new Category { Id = 2, Name = "Repairs" } };
            demoData[typeof(SubCategory)] = new List<SubCategory> { new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 }, new SubCategory { Id = 2, Name = "Pizza", CategoryId = 1 } };

            demoData[typeof(Review)] = new List<Review>()
            {
                new Review {
                    Id = 1,
                    Content = "voolaa",
                    Rate = 4.5f,
                    ReviewerId = 2,
                    BusinessId = 3,
                    CreatedDate = DateTime.Now - TimeSpan.FromHours(1)
                },
            };
        }
        public Task<bool> AddAsync(T entity)
        {
            //(entity as Review)!.Id = 20;
            //(entity as Review)!.CreatedDate = DateTime.Now;
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

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            return Task.FromResult((IReadOnlyList<T>)demoData[typeof(T)]);
        }

        public Task<T> SelectOneAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> SelectAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
