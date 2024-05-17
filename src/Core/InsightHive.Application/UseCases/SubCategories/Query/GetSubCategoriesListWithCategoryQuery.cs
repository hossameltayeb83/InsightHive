using MediatR;

namespace InsightHive.Application.UseCases.SubCategories.Query
{
    public class GetSubCategoriesListWithCategoryQuery : IRequest<CategoryWithSubcategoriesDto>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
