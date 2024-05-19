using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory
{
    public class GetAllBusinessesForSubCategoryQuery : IRequest<BaseResponse<List<BusinessSearchDto>>>
    {
        public int SubCategoryId { get; set; }
        public string? Search { get; set; }
        public string? Options { get; set; }
    }
}
