using InsightHive.Application.UseCases.SubCategories.Query;

namespace InsightHive.Application.UseCases.Categories.Query.GetAllCategories
{
    public class CategoryListDto
    {
        public string Name { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; } = new List<SubcategoryDto>();
    }
}

