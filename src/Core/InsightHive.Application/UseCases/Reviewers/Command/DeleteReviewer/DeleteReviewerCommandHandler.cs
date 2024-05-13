using InsightHive.Application.Interfaces.Persistence;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.DeleteReviewer
{
    public class DeleteReviewerCommandHandler : IRequestHandler<DeleteReviewerCommand>
    {
        private readonly IReviewerRepository _reviewerRepo;

        public DeleteReviewerCommandHandler(IReviewerRepository reviewerRepo)
        {
            _reviewerRepo = reviewerRepo;
        }

        public async Task Handle(DeleteReviewerCommand request, CancellationToken cancellationToken)
        {
            var reviewerToDelete = await _reviewerRepo.GetByIdWithUserAsync(request.Id);
            var user = await _reviewerRepo.GetByUserIdWithUserAsync(request.UserId);


            if (user == null)
                throw new Exceptions.NotAuthorizedException("Not authorized!");

            if (reviewerToDelete == null)
                throw new Exceptions.NotFoundException("Reviewer not found!");

            if ( reviewerToDelete.User.Id != request.UserId || user.User?.RoleId != 1 )
                throw new Exceptions.NotAuthorizedException("Not authorized to delete this reviewer!");


            await _reviewerRepo.DeleteAsync(reviewerToDelete);

        }
    }
}
