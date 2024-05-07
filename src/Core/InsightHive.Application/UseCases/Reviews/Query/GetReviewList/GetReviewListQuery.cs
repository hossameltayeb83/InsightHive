using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewList
{
    public class GetReviewListQuery : IRequest<BaseResponse<PaginatedList<ReviewDto, Review>>>
    {
        public int BusinessId { get; init; }
        public int MaxComments { get; init; }
        public int Page { get; init; }
        public int PageSize { get; init; }
    }
}
