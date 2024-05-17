namespace InsightHive.Application.UseCases.SubCategories.Query
{
    public class CategoryWithSubcategoriesDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }

    }
}
