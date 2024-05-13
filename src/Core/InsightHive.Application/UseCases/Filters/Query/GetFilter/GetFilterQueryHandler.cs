using AutoMapper;
using InsightHive.Application.Exceptions;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Query.GetFilter
{
    internal class GetFilterQueryHandler : IRequestHandler<GetFilterQuery, BaseResponse<FilterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Filter> _filterRepository;

        public GetFilterQueryHandler(IMapper mapper, IRepository<Filter> filterRepository)
        {
            _mapper = mapper;
            _filterRepository = filterRepository;
        }
        public async Task<BaseResponse<FilterDto>> Handle(GetFilterQuery request, CancellationToken cancellationToken)
        {
            var filter = await _filterRepository.GetByIdAsync(request.Id);
            if (filter == null)
                throw new NotFoundException("No Filter with the provided Id.");
            var response = new BaseResponse<FilterDto>();
            response.Result = _mapper.Map<FilterDto>(filter);
            return response;
        }
    }
}
