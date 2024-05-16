using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId);
    }
}