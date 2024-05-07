using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Owners.command.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
    {

        private readonly IRepository<Owner> _ownerRepo;
        private readonly IMapper _mapper;

        public UpdateOwnerCommandHandler(IRepository<Owner> ownerRepo,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepo = ownerRepo;
        }
        public async Task Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var validetor = new UpdateOwnerCommandValidetor();
            var validationResult = await validetor.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var Owner = await _ownerRepo.GetByIdAsync(request.ownerDto.Id);
            await _ownerRepo.UpdateAsync(Owner);

        
            
        }
    }
}
