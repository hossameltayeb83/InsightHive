using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
    }
}
