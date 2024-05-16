using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class SearchRepository : BaseRepository<Business>, ISearchRepository
    {
        public SearchRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Business>> GetAllByCategorySearch(string searchQuery, int[] optionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(string searchQuery, int[] optionsIds)
        {
            throw new NotImplementedException();
        }
    }
}
