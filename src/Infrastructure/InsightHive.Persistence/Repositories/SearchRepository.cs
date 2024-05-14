using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Repositories
{
    internal class SearchRepository : ISearchRepository
    {
        public Task<bool> AddAsync(Business entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Business entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllByCategorySearch(int categoryId, string? searchQuery, int[]? optionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(int subCategoryId, string? searchQuery, int[]? optionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<Business> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Business> SelectAllAsync(Expression<Func<Business, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> SelectOneAsync(Expression<Func<Business, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Business entity)
        {
            throw new NotImplementedException();
        }
    }
}
