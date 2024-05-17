using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetCommentList
{
    public class GetCommentListQueryHandler :
        IRequestHandler<GetCommentListQuery, BaseResponse<PaginatedList<CommentDto, Comment>>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(IReviewRepository reviewRepo,
                                                IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<CommentDto, Comment>>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {

            IQueryable<Comment> comments = await _reviewRepo.GetCommentListAsync(request.ReviewId);

            var result = await PaginatedList<CommentDto, Comment>.CreateAsync(comments, _mapper, request.Page, request.PageSize);

            string msg = result.TotalCount > 0 ? "Comments successfully retrieved" : "No comments!";

            return new BaseResponse<PaginatedList<CommentDto, Comment>> { Message = msg, Result = result };
        }
    }
}
