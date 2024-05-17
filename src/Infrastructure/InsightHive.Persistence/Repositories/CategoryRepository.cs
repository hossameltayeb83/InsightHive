using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<List<Category>> GetAllCategoriesWithSubCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdWithSubCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByNameWithSubCategoriesAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
