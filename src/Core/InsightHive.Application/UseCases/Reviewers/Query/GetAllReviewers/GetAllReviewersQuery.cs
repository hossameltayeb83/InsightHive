using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers
{
    public class GetAllReviewersQuery : IRequest<BaseResponse<IReadOnlyList<ReviewerListDto>>>
    {
    }
}
