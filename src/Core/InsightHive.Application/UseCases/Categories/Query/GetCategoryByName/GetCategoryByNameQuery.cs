using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{
    public class GetCategoryByNameQuery : IRequest<BaseResponse<CategoryByNameDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
