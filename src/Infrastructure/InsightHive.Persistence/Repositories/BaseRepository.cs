using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InsightHive.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly InsightHiveDbContext _context;
        public BaseRepository(InsightHiveDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
