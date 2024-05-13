﻿using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers
{
    internal class GetAllReviewersQueryHandler : IRequestHandler<GetAllReviewersQuery, BaseResponse<IReadOnlyList<ReviewerListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Reviewer> _reviewerRepository;

        public GetAllReviewersQueryHandler(IMapper mapper, IRepository<Reviewer> reviewerRepository)
        {
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
        }

        public async Task<BaseResponse<IReadOnlyList<ReviewerListDto>>> Handle(GetAllReviewersQuery request, CancellationToken cancellationToken)
        {
            var reviewers = await _reviewerRepository.ListAllAsync();
            var reviewersDtos = _mapper.Map<IReadOnlyList<ReviewerListDto>>(reviewers);
            var response = new BaseResponse<IReadOnlyList<ReviewerListDto>>() { Result = reviewersDtos };
            return response;
        }
    }
}
