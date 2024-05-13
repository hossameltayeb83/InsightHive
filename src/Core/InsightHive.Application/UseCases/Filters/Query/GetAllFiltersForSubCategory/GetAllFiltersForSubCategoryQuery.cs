using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForSubCategory
{
    public class GetAllFiltersForSubCategoryQuery: IRequest<BaseResponse<List<FilterDto>>>
    {
        public int SubCategoryId { get; set; }
    }
}
