using InsightHive.Application.UseCases.SubCategories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{
    public class CategoryByNameDto
    {
        public string Name { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; } = new List<SubcategoryDto>();
    }
}

