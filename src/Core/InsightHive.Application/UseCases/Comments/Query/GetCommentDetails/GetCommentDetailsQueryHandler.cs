using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Comments.Query.GetCommentDetails;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails
{
    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, BaseResponse<CommentDto>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public GetCommentDetailsQueryHandler(IReviewRepository reviewRepo,
                                         IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CommentDto>> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {

            var reviewComment = await _reviewRepo.GetCommentAsync(request.CommentId);

            if (reviewComment == null)
                throw new Exceptions.NotFoundException("Comment not found!");

            var commentDto = _mapper.Map<CommentDto>(reviewComment);

            var response = new BaseResponse<CommentDto> { Message = "Retrieved successfully", Result = commentDto };
            return response;
        }
    }
}
