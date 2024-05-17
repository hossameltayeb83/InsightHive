using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Comments.Query.GetCommentDetails;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails
{
    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, BaseResponse<CommentDto>>
    {
        private readonly IRepository<Comment> _commentRepo;
        private readonly IMapper _mapper;

        public GetCommentDetailsQueryHandler(IRepository<Comment> commentRepo,
                                         IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CommentDto>> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepo.GetByIdAsync(request.Id);

            if (comment == null)
                throw new Exceptions.NotFoundException("Comment not found!");

            var commentDto = _mapper.Map<CommentDto>(comment);

            return new BaseResponse<CommentDto> { Message = "Retrieved successfully", Result = commentDto };
        }
    }
}
