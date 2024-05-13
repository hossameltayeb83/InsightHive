using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class GetReviewerQueryHandler : IRequestHandler<GetReviewerQuery, BaseResponse<ReviewerDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;

        public GetReviewerQueryHandler(
            IMapper mapper,
            IReviewerRepository reviewerRepository)
        {
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
        }
        public async Task<BaseResponse<ReviewerDetailsDto>> Handle(GetReviewerQuery request, CancellationToken cancellationToken)
        {
            var reviewer = await _reviewerRepository.GetByIdWithReviewsAndBadgesAsync(request.Id);
            var reviewerDto = _mapper.Map<ReviewerDetailsDto>(reviewer);
            var response = new BaseResponse<ReviewerDetailsDto>() { Result = reviewerDto };
            return response;
        }
    }
}
