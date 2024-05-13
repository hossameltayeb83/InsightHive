using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetCommentList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery,
                                                                    BaseResponse<PaginatedList<CommentDto, ReviewComment>>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(IReviewRepository reviewRepo,
                                                IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<CommentDto, ReviewComment>>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {

            IQueryable<ReviewComment> reviewComments = await _reviewRepo.GetCommentListAsync(request.ReviewId);

            var result = await PaginatedList<CommentDto, ReviewComment>.CreateAsync(reviewComments, _mapper, request.Page, request.PageSize);

            string msg = result.TotalCount > 0 ? "Comments successfully retrieved" : "No comments!";

            var response = new BaseResponse<PaginatedList<CommentDto, ReviewComment>> { Message = msg, Result = result };

            return response;
        }
    }
}
