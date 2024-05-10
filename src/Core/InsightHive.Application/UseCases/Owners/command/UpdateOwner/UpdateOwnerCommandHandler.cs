using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Application.UseCases.Owners.command.CreateOwner;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InsightHive.Application.UseCases.Owners.command.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, BaseResponse<OwnerDto>>
    {

        private readonly IRepository<Owner> _ownerRepo;
        private readonly IMapper _mapper;

        public UpdateOwnerCommandHandler(IRepository<Owner> ownerRepo,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepo = ownerRepo;
        }
        public async Task<BaseResponse<OwnerDto>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var validetor = new UpdateOwnerCommandValidetor();
            var validationResult = await validetor.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var Owner = await _ownerRepo.GetByIdAsync(request.ownerDto.Id);

            if (Owner == null)
            {
                throw new Exceptions.NotFoundException("owner not found");
            }

            _mapper.Map(request.ownerDto, Owner); 

            var updated = await _ownerRepo.UpdateAsync(Owner);

            var response = new BaseResponse<OwnerDto>();

            if (updated)
            {
                response.Message = "Owner updated successfully.";
                response.Result = _mapper.Map<OwnerDto>(Owner);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the Owner!";
            }

            return response;




        }
    }
}
