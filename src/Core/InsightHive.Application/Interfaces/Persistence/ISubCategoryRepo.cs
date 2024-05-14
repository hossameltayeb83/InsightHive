using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ISubCategoryRepo : IRepository<SubCategory>
    {
        Task<List<SubCategory>> GetByCategoryIdAsync(int categoryId);
    }
}