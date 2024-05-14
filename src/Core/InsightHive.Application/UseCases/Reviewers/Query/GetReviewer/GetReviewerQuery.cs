using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class GetReviewerQuery : IRequest<BaseResponse<ReviewerDetailsDto>>
    {
        public int Id { get; set; }
    }
}
