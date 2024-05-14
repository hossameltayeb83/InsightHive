using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss
{
    public class UpdateBussnissCommandHandler : IRequestHandler<UpdateBussnissCommand, BaseResponse<BussniessDto>>
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
        public async Task<BaseResponse<BussniessDto>> Handle(UpdateBussnissCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBussnissCommandValidetor();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var response = new BaseResponse<BussniessDto>();
            var businessToUpdate = await _businessRepo.GetByIdAsync(request.Id);

            if (businessToUpdate == null)
            {
                throw new Exceptions.NotFoundException("Business not found");
            }

            _mapper.Map(request, businessToUpdate);

            var updated = await _businessRepo.UpdateAsync(businessToUpdate);

            if (updated)
            {
                response.Message = "Business updated successfully.";
                response.Result = _mapper.Map<BussniessDto>(businessToUpdate);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the business!";
            }

            return response;
        }

    }
}
