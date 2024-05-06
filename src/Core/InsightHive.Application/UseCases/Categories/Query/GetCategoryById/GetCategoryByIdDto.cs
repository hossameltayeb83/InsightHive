using InsightHive.Application.UseCases.SubCategories.Query;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; } = new List<SubcategoryDto>();
    }
}
