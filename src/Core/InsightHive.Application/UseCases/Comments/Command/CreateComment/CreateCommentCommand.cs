using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateComment
{
    public class CreateCommentCommand : IRequest<BaseResponse<CommentDto>>
    {
        public int CommenterId { get; set; }
        public int ReviewId { get; set; }
        public string Content { get; set; }
    }
}
