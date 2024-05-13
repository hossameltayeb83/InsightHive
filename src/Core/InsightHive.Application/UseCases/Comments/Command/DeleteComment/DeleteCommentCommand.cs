using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
