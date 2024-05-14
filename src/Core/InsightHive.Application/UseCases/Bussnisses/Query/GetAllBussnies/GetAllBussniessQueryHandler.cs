using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies
{

    public class GetAllBussniessQueryHandler : IRequestHandler<GetAllBussniessQuery, BaseResponse<List<BussniessDto>>>
    {

        private readonly IRepository<Business> _businessRepo;
        private readonly IMapper _mapper;

        public GetAllBussniessQueryHandler(IRepository<Business> businessRepo,
                                            IMapper mapper
                                            )
        {
            _businessRepo = businessRepo;
            _mapper = mapper;

        }
        public async Task<BaseResponse<List<BussniessDto>>> Handle(GetAllBussniessQuery request, CancellationToken cancellationToken)
        {
            var AllBusniess = await _businessRepo.ListAllAsync();
            if ( AllBusniess == null )
            {
                throw new Exceptions.NotFoundException("Businesses not found");
            }
            var response= new BaseResponse<List<BussniessDto>>();
            response.Message = "All businesses found";
            response.Result= _mapper.Map<List<BussniessDto>>(AllBusniess);
            return response;

        }
    }
}
