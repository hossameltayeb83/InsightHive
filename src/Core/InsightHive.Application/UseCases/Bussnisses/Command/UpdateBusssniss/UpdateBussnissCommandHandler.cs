using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss
{
    public class UpdateBussnissCommandHandler:IRequestHandler<UpdateBussnissCommand>
    {
        private readonly IRepository<Business> _businessRepo;
        private readonly IMapper _mapper;

        public UpdateBussnissCommandHandler(IRepository<Business> businessRepo,
                                            IMapper mapper
                                            )
        {
            _businessRepo = businessRepo;
            _mapper = mapper;

        }

        public async Task Handle(UpdateBussnissCommand request, CancellationToken cancellationToken)
        {
            var Updatedbussniss = await _businessRepo.GetByIdAsync(request.Id);
            _mapper.Map(request, Updatedbussniss);
            await _businessRepo.UpdateAsync(Updatedbussniss);

        }
    }
}
