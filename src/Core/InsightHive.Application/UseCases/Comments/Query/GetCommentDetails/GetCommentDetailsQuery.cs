using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Comments.Query.GetCommentDetails
{
    public class GetCommentDetailsQuery : IRequest<BaseResponse<CommentDto>>
    {
        public int Id { get; init; }
    }
}
