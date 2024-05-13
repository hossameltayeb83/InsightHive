using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetCommentList
{
    public class GetCommentListQuery : IRequest<BaseResponse<PaginatedList<CommentDto, Comment>>>
    {
        public int ReviewId { get; init; }
        public int Page { get; init; }
        public int PageSize { get; init; }
    }
}
