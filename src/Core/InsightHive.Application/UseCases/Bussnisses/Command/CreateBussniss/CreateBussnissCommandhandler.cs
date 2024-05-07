﻿using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss
{
    public class CreateBussnissCommandhandler : IRequestHandler<CreateBussnissCommand,BussniessDto>
    {

        private readonly IRepository<Business> _businessRepo;
        private readonly IMapper _mapper;

        public CreateBussnissCommandhandler(IRepository<Business> businessRepo, 
                                            IMapper mapper
                                            )
        {
            _businessRepo = businessRepo;
            _mapper = mapper;

        }

        public async Task<BussniessDto> Handle(CreateBussnissCommand request, CancellationToken cancellationToken)
        {


            var validetor = new CreateBussnissCommandValidetor();
            var validationResult = await validetor.ValidateAsync(request);
            if (validationResult.Errors.Count>0) 
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var newBusiness = _mapper.Map<Business>(request.bussniessDto);
            await _businessRepo.AddAsync(newBusiness);
            return _mapper.Map<BussniessDto>(newBusiness);

        }
    }
}
