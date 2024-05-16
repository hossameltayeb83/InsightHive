using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Repositories
{
    public class FilterRepository : BaseRepository<Filter>, IFilterRepository
    {
        public FilterRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Filter>> GetAllByCategoryIdAsync(int categoryId)
        {
            var filters = await _context.Categories
                .Include(e => e.Filters)
                .ThenInclude(e => e.Options)
                .Where(e => e.Id == categoryId)
                .SelectMany(e => e.Filters)
                .ToListAsync();
            return filters.AsReadOnly();
        }

        public async Task<IReadOnlyList<Filter>> GetAllBySubCategoryIdAsync(int subCategoryId)
        {
            var filters = await _context.SubCategories
                .Include(e=>e.Category)
                .ThenInclude(e=>e.Filters)
                .ThenInclude(e=>e.Options)
                .Where(e => e.Id == subCategoryId)
                .SelectMany(e => e.Category.Filters).ToListAsync();
            return filters.AsReadOnly();
        }
    }
}
