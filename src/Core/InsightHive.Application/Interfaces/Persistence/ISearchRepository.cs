using InsightHive.Application.UseCases.Search.Query;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ISearchRepository : IRepository<Business>
    {
        Task<IReadOnlyList<Business>> GetAllBySearch(string searchQuery);
        Task<IReadOnlyList<Business>> GetAllByCategorySearch(int categoryId,string? searchQuery, int[]? optionsIds);
        Task<IReadOnlyList<Business>> GetAllBySubCategorySearch(int subCategoryId,string? searchQuery, int[]? optionsIds);
    }
}
