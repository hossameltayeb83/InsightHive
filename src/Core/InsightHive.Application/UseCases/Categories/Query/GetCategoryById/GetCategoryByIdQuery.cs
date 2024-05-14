using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<BaseResponse<GetCategoryByIdDto>>
    {
        public int CategoryId { get; set; }
    }
}
