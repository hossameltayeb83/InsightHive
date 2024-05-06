using AutoMapper;
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
    public class CreateBussnissCommandhandler : IRequestHandler<CreateBussnissCommand>
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

        public async Task Handle(CreateBussnissCommand request, CancellationToken cancellationToken)
        {
            var newBusiness = _mapper.Map<Business>(request.bussniessDto);
            await _businessRepo.AddAsync(newBusiness);

        }
    }
}
