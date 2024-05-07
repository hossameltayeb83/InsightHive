using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetBussnissById
{
    public class GetBussnissByIdQueryHandler : IRequestHandler<GetBussnissByIdQuery, BussniessDto>
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

        public async Task<BussniessDto> Handle(GetBussnissByIdQuery request, CancellationToken cancellationToken)
        {
            var bussniss = await _businessRepo.GetByIdAsync( request.Id );
            var bussnissResult = _mapper.Map<BussniessDto>(bussniss);
            return (bussnissResult);
        }
    }
}
