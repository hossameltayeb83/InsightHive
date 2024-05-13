using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.DeleteReviewer
{
    public class DeleteReviewerCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
