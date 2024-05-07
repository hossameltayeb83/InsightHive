using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Owners.command.CreateOwner
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, OwnerDto>
    {

        private readonly IRepository<Owner> _ownerRepo;
        private readonly IMapper _mapper;

        public CreateOwnerCommandHandler(IRepository<Owner> ownerRepo,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepo = ownerRepo;
        }
        public async Task<OwnerDto> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var validetor = new CreateOwnerCommandValidetor();
            var validationResult = await validetor.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var NewOwner = _mapper.Map<Owner>(request.ownerDto);
            await _ownerRepo.AddAsync(NewOwner);
            return _mapper.Map<OwnerDto>(NewOwner);
        }
    }
}
