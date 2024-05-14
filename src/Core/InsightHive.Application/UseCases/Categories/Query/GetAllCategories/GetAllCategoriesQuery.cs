using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<BaseResponse<List<CategoryListDto>>>
    {
    }
}
