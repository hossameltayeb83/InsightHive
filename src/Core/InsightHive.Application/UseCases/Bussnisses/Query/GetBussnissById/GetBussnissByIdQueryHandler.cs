using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetBussnissById
{
    public class GetBussnissByIdQueryHandler : IRequestHandler<GetBussnissByIdQuery, BaseResponse<BussniessDto>>
    {

        private readonly IRepository<Business> _businessRepo;
        private readonly IMapper _mapper;

        public GetBussnissByIdQueryHandler(IRepository<Business> businessRepo,
                                            IMapper mapper
                                            )
        {
            _businessRepo = businessRepo;
            _mapper = mapper;

        }

        public async Task<BaseResponse<BussniessDto>> Handle(GetBussnissByIdQuery request, CancellationToken cancellationToken)
        {
            var bussniss = await _businessRepo.GetByIdAsync(request.Id);
            if (bussniss == null)
            {
                throw new Exceptions.NotFoundException("Business not found");
            }
            var response = new BaseResponse<BussniessDto>();
            response.Message = "Business found";
            response.Result = _mapper.Map<BussniessDto>(bussniss);
            return (response);
        }
    }
}
