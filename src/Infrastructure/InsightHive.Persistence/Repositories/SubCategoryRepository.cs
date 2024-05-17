using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Repositories
{
    internal class SubCategoryRepository : BaseRepository<SubCategoryRepository>, ISubCategoryRepository
    {
        public SubCategoryRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<bool> AddAsync(Domain.Entities.SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Domain.Entities.SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Domain.Entities.SubCategory entity)
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.SubCategory> IRepository<Domain.Entities.SubCategory>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Domain.Entities.SubCategory>> IRepository<Domain.Entities.SubCategory>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
