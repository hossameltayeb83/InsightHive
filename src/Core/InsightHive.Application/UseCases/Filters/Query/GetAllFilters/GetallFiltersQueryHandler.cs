using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetAllFilters
{
    internal class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, BaseResponse<List<FilterDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Filter> _filterRepository;

        public GetAllFiltersQueryHandler(IMapper mapper, IRepository<Filter> filterRepository)
        {
            _mapper = mapper;
            _filterRepository = filterRepository;
        }
        public async Task<BaseResponse<List<FilterDto>>> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
        {
            var filters = await _filterRepository.ListAllAsync();
            var response = new BaseResponse<List<FilterDto>>();
            response.Result = _mapper.Map<List<FilterDto>>(filters);
            return response;
        }
    }
}
