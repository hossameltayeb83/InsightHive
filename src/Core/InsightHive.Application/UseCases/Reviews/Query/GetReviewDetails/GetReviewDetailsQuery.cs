using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails
{
    public class GetReviewDetailsQuery : IRequest<BaseResponse<ReviewDto>>
    {
        public int ReviewId { get; init; }
        public int MaxComments { get; init; }
    }
}
