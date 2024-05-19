using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.RemoveReaction
{
    public class RemoveReactionCommandHandler : IRequestHandler<RemoveReactionCommand>
    {
        private readonly IReviewReactionRepository _reviewReactionRepo;
        private readonly IValidator<RemoveReactionCommand> _validator;

        public RemoveReactionCommandHandler(IReviewReactionRepository reviewReactionRepo)
        {
            _reviewReactionRepo = reviewReactionRepo;
            _validator = new RemoveReactionCommandValidator();
        }
        public async Task Handle(RemoveReactionCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var deleted = await _reviewReactionRepo.DeleteAsync(request.ReviewId, request.ReviewerId);


            if (!deleted)
                throw new Exceptions.BadRequestException("one or more value is not valid!");
        }
    }
}
