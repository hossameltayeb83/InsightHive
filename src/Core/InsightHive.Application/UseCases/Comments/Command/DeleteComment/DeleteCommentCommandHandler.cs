using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IRepository<Comment> _commentRepo;

        public DeleteCommentCommandHandler(IRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToDelete = await _commentRepo.GetByIdAsync(request.Id);

            if (commentToDelete == null)
                throw new Exceptions.NotFoundException("Comment not found!");

            // TODO: authorize before delete
            //if (commentToDelete.ReviewerId != request.CommenterId)
            //    throw new Exceptions.NotAuthorizedException("Not authorized to delete this comment!");

            await _commentRepo.DeleteAsync(commentToDelete);

        }
    }
}
