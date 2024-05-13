using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
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

    internal class GetAllFiltersForSubCategoryQueryHandler : IRequestHandler<GetAllFiltersForSubCategoryQuery, BaseResponse<List<FilterDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IFilterRepository _filterRepository;

        public GetAllFiltersForSubCategoryQueryHandler(IMapper mapper, IFilterRepository filterRepository)
        {
            _mapper = mapper;
            _filterRepository = filterRepository;
        }
        public async Task<BaseResponse<List<FilterDto>>> Handle(GetAllFiltersForSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var filters = await _filterRepository.GetAllByCategoryIdAsync(request.SubCategoryId);
            var response= new BaseResponse<List<FilterDto>>();
            response.Result = _mapper.Map<List<FilterDto>>(filters);
            return response;
        }
    }
}
