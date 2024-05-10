using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IFilterRepository : IRepository<Filter>
    {
        Task<IReadOnlyList<Filter>> GetAllByCategoryIdAsync(int categoryId);
        Task<IReadOnlyList<Filter>> GetAllBySubCategoryIdAsync(int subCategoryId);
    }
}
