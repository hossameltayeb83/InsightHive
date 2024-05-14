using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByIdWithSubCategoriesAsync(int id);
        Task<Category> GetByNameWithSubCategoriesAsync(string name);
        Task<List<Category>> GetAllCategoriesWithSubCategoriesAsync();



    }
}
