using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Command.DeleteBussniss
{
    public class DeleteBussnissCommandHandler : IRequestHandler<DeleteBussnissCommand>
    {
        private readonly IRepository<Business> _businessRepo;
        private readonly IMapper _mapper;

        public DeleteBussnissCommandHandler(IRepository<Business> businessRepo,
                                            IMapper mapper
                                            )
        {
            _businessRepo = businessRepo;
            _mapper = mapper;

        }

        public async Task Handle(DeleteBussnissCommand request, CancellationToken cancellationToken)
        {
            var bussnisstodelete = await _businessRepo.GetByIdAsync(request.Id);
            await _businessRepo.DeleteAsync(bussnisstodelete);

        }
    }
}
