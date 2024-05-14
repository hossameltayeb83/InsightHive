using InsightHive.Application.UseCases.SubCategories.Query;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{
    public class CategoryByNameDto
    {
        public string Name { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; } = new List<SubcategoryDto>();
    }
}

