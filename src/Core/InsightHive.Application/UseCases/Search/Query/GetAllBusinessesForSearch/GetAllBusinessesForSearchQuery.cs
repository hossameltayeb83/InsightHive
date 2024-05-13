using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSearch
{
    public class GetAllBusinessesForSearchQuery : IRequest<BaseResponse<List<BusinessSearchDto>>>
    {
        public string Query { get; set; }
    }
}
