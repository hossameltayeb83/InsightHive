using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFilters
{
    public class GetAllFiltersQuery : IRequest<BaseResponse<List<FilterDto>>>
    {
    }
}
