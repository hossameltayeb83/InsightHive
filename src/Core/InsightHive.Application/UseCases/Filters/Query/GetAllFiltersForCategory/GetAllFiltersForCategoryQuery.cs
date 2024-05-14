using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForCategory
{
    public class GetAllFiltersForCategoryQuery : IRequest<BaseResponse<List<FilterDto>>>
    {
        public int CategoryId { get; set; }
    }
}
