using InsightHive.Application.Interfaces.Persistence;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _reviewRepo;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToDelete = await _reviewRepo.GetByIdAsync(request.Id);

            if (reviewToDelete == null)
                throw new Exceptions.NotFoundException("Review not found!");

            if (reviewToDelete.ReviewerId != request.ReviewerId)
                throw new Exceptions.NotAuthorizedException("Not authorized to delete this review!");


            await _reviewRepo.DeleteAsync(reviewToDelete);

            //var response = new UpdateReviewResponse();
            //if (deleted)
            //{
            //    response.Message = "Review deleted successfully.";
            //}
            //else
            //{
            //    response.Success = false;
            //    response.Message = "Failed to delete the review!";
            //}

            //return deleted;
        }
    }
}
