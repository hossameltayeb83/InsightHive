using InsightHive.Application.UseCases.SubCategories.Query;

namespace InsightHive.Application.UseCases.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; } = new List<SubcategoryDto>();
    }
}
