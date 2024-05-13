using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ISearchRepository : IRepository<Business>
    {
        Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery);
        Task<IReadOnlyList<Business>> GetAllByCategorySearch(string searchQuery, int[] optionsIds);
        Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(string searchQuery, int[] optionsIds);
    }
}
