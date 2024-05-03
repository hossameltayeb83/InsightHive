using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.PersistenceDemo
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        Dictionary<Type,IEnumerable> demoData = new Dictionary<Type,IEnumerable>();
        
        
        public BaseRepository()
        {
            demoData[typeof(Category)] = new List<Category> { new Category { Id=1,Name="Restaurants" },new Category {Id=2,Name="Repairs" } };
        }
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            return Task.FromResult((IReadOnlyList<T>)demoData[typeof(T)]);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
