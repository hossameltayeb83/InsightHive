using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InsightHive.Persistence.Repositories
{
    public class BusinessRepository : BaseRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(InsightHiveDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery)
        {
            var businesses = await _context.Businesses
                .Where(e => e.Name.Contains(searchQuery))
                .ToListAsync();
            return businesses.AsReadOnly();
        }
        public async Task<IReadOnlyList<Business>> GetAllByCategorySearch(int categoryId, string searchQuery, int[] optionsIds)
        {
            var businesses = _context.SubCategories
                .Where(e => e.CategoryId == categoryId);
            return await Search(businesses, searchQuery, optionsIds);
        }

        public async Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(int subCategoryId, string searchQuery, int[] optionsIds)
        {
            var businesses = _context.SubCategories
                .Where(e => e.Id == subCategoryId);
            return await Search(businesses, searchQuery, optionsIds);
        }
        private async Task<IReadOnlyList<Business>> Search(IQueryable<SubCategory> subCategories, string searchQuery, int[] optionsIds)
        {
            var businesses = subCategories.SelectMany(e => e.Businesses);
            if (!searchQuery.IsNullOrEmpty())
            {
                businesses.Where(e => e.Name.Contains(searchQuery));
            }
            if (!optionsIds.IsNullOrEmpty())
            {
                businesses.Where(e => e.Options.All(e => optionsIds.Contains(e.Id)));
            }
            var SearchResult = await businesses.ToListAsync();
            return SearchResult.AsReadOnly();
        }
    }
}
