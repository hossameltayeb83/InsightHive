using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails
{
    public class GetReviewDetailsQueryHandler : IRequestHandler<GetReviewDetailsQuery, BaseResponse<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public GetReviewDetailsQueryHandler(IReviewRepository reviewRepo,
                                         IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ReviewDto>> Handle(GetReviewDetailsQuery request, CancellationToken cancellationToken)
        {

            var review = await _reviewRepo.GetReviewByIdAsync(request.ReviewId, request.MaxComments);

            if (review == null)
                throw new Exceptions.NotFoundException("Review not found!");

            var reviewDto = _mapper.Map<ReviewDto>(review);

            var response = new BaseResponse<ReviewDto> { Message = "Retrieved successfully", Result = reviewDto };
            return response;
        }
    }
}
