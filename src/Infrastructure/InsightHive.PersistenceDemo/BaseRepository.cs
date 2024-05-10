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
        Dictionary<Type,IList> demoData = new Dictionary<Type,IList>();
        
        
        public BaseRepository()
        {
            demoData[typeof(Category)] = new List<Category> { new Category { Id=1,Name="Restaurants" },new Category {Id=2,Name="Repairs" } };
            demoData[typeof(SubCategory)] = new List<SubCategory> { new SubCategory { Id=1,Name="Burger",CategoryId=1 },new SubCategory {Id=2,Name="Pizza",CategoryId=1 } };
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
            var list= (List<T>)demoData[typeof(T)];
            Func<dynamic,bool> predicate = (list) => list.Id==id;
            return Task.FromResult(list.FirstOrDefault(predicate));
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
    }
}
