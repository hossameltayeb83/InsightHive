using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;

namespace InsightHive.PersistenceDemo.Repositories
{
    internal class SearchRepository : BaseRepository<Business>
    {
        public Task<IReadOnlyList<Business>> GetAllByCategorySearch(string searchQuery, int[] optionsIds)
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

        public Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(string searchQuery, int[] optionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(int subCategoryId, string? searchQuery, int[]? optionsIds)
        {
            throw new NotImplementedException();
        }
    }
}
