using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForCategory
{
    internal class GetAllFiltersForCategoryQueryHandler : IRequestHandler<GetAllFiltersForCategoryQuery, BaseResponse<List<FilterDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IFilterRepository _filterRepository;

        public GetAllFiltersForCategoryQueryHandler(IMapper mapper,IFilterRepository filterRepository)
        {
            _mapper = mapper;
            _filterRepository = filterRepository;
        }
        public async Task<BaseResponse<List<FilterDto>>> Handle(GetAllFiltersForCategoryQuery request, CancellationToken cancellationToken)
        {
            var filters = await _filterRepository.GetAllByCategoryIdAsync(request.CategoryId);
            var response = new BaseResponse<List<FilterDto>>();
            response.Result =_mapper.Map<List<FilterDto>>(filters);
            return response;
        }
    }
}
