using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;

namespace InsightHive.PersistenceDemo
{
    internal class FilterRepository : BaseRepository<Filter>, IFilterRepository
    {
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
