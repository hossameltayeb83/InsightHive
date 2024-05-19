using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForCategory
{
    public class GetAllBusinessesForCategoryQuery : IRequest<BaseResponse<List<BusinessSearchDto>>>
    {
        public int CategoryId { get; set; }
        public string? Search { get; set; }
        public string? Options { get; set; }
    }
}
