using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class GetReviewerQueryHandler : IRequestHandler<GetReviewerQuery, ReviewerDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Reviewer> _reviewerRepository;

        public GetReviewerQueryHandler(
            IMapper mapper,
            IRepository<Reviewer> reviewerRepository)
        {
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
        }
        public async Task<ReviewerDetailsDto> Handle(GetReviewerQuery request, CancellationToken cancellationToken)
        {
            var reviewer = await _reviewerRepository.GetByIdAsync(request.Id);
            var reviewerDto = _mapper.Map<ReviewerDetailsDto>(reviewer);

            //enject the two list repos and assign them inside the reviewerDto

            return reviewerDto;
        }
    }
}
