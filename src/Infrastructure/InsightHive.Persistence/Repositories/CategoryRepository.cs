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
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllCategoriesWithSubCategoriesAsync()
        {
            return await _context.Categories
                .Include(e=>e.SubCategories)
                .ToListAsync();
        }

        public async Task<Category> GetByIdWithSubCategoriesAsync(int id)
        {
            return await _context.Categories
                .Include(e => e.SubCategories)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Category> GetByNameWithSubCategoriesAsync(string name)
        {
            return await _context.Categories
                .Include(e => e.SubCategories)
                .FirstOrDefaultAsync(e => e.Name == name );
        }
    }
}
