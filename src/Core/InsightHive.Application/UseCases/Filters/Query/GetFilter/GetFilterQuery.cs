using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetFilter
{
    public class GetFilterQuery : IRequest<BaseResponse<FilterDto>>
    {
        public int Id { get; set; }
    }
}
