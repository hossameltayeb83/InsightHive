using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryListDto>>
    {
    }
}
