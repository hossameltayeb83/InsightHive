using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateComment
{
    public class UpdateCommentCommand : IRequest<BaseResponse<CommentDto>>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
