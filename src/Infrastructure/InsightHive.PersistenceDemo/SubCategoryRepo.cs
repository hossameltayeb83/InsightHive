using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.PersistenceDemo
{
    public class SubCategoryRepo : ISubCategoryRepo
    {
        public Task<bool> AddAsync(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetByIdAsync(int id)
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
