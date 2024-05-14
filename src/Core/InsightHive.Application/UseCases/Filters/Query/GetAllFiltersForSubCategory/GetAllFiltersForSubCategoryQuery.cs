using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForSubCategory
{
    public class GetAllFiltersForSubCategoryQuery : IRequest<BaseResponse<List<FilterDto>>>
    {
        public int SubCategoryId { get; set; }
    }
}
