using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers
{
    internal class GetAllReviewersQueryHandler : IRequestHandler<GetAllReviewersQuery, IReadOnlyList<ReviewerListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Reviewer> _reviewerRepository;

        public GetAllReviewersQueryHandler(IMapper mapper, IRepository<Reviewer> reviewerRepository)
        {
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
        }

        public async Task<IReadOnlyList<ReviewerListDto>> Handle(GetAllReviewersQuery request, CancellationToken cancellationToken)
        {
            var reviewers = await _reviewerRepository.ListAllAsync();
            var reviewersDtos = _mapper.Map<IReadOnlyList<ReviewerListDto>>(reviewers);
            return reviewersDtos;
        }
    }
}
