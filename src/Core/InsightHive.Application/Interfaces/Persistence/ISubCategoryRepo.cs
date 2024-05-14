using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ISubCategoryRepo : IRepository<SubCategory>
    {
        Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId);
    }
}