using System.Linq.Expressions;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IReadOnlyList<T>> SelectOneAsync(Expression<Func<T, bool>> predicate);
        Task<T> SelectAllAsync(Expression<Func<T, bool>> predicate);

    }
}
