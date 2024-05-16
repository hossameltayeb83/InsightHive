using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IBusinessRepository : IRepository<Business>
    {
        Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery);
        Task<IReadOnlyList<Business>> GetAllByCategorySearch(int categoryId,string searchQuery, int[] optionsIds);
        Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(int subCategoryId,string searchQuery, int[] optionsIds);
    }
}
