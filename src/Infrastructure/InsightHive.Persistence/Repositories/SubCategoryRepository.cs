using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.Persistence.Repositories
{
    internal class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public async Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            var a = await _context.Categories
                .Include(e => e.SubCategories)
                .FirstOrDefaultAsync(e => e.Id == categoryId);
            return a.SubCategories.ToList();
        }
    }
}
