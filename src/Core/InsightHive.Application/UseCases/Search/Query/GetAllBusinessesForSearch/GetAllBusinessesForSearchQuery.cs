using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSearch
{
    public class GetAllBusinessesForSearchQuery : IRequest<BaseResponse<List<BusinessSearchDto>>>
    {
        public string Query { get; set; }
    }
}
