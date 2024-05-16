using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class FilterRepository : BaseRepository<Filter>, IFilterRepository
    {
        public FilterRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Filter>> GetAllByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Filter>> GetAllBySubCategoryIdAsync(int subCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
