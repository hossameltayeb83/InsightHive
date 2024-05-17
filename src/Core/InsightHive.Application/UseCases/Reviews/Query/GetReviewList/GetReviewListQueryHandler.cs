using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewList
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, BaseResponse<PaginatedList<ReviewDto, Review>>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public GetReviewListQueryHandler(IReviewRepository reviewRepo,
                                         IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<ReviewDto, Review>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {

            IQueryable<Review> reviews =
                await _reviewRepo.GetReviewsByBusinessIdAsync(request.BusinessId, request.MaxComments);

            var response = new BaseResponse<PaginatedList<ReviewDto, Review>>();
            response.Result = await PaginatedList<ReviewDto, Review>.CreateAsync(reviews, _mapper, request.Page, request.PageSize);

            return response;
        }
    }
}
