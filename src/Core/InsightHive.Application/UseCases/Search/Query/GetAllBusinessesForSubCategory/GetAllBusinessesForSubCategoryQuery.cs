using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory
{
    public class GetAllBusinessesForSubCategoryQuery : IRequest<BaseResponse<List<BusinessSearchDto>>>
    {
        public int SubCategoryId { get; set; }
        public string? Query { get; set; }
        public string? Options { get; set; }
    }
}
