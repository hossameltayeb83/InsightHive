using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IFilterRepository : IRepository<Filter>
    {
        Task<IReadOnlyList<Filter>> GetAllByCategoryIdAsync(int categoryId);
        Task<IReadOnlyList<Filter>> GetAllBySubCategoryIdAsync(int subCategoryId);
    }
}
