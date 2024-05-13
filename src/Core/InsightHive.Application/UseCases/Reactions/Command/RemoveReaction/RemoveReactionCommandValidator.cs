using FluentValidation;

namespace InsightHive.Application.UseCases.Reactions.Command.RemoveReaction
{
    public class RemoveReactionCommandValidator : AbstractValidator<RemoveReactionCommand>
    {
        public RemoveReactionCommandValidator()
        {
            RuleFor(p => p.ReviewId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ReviewerId).GreaterThan(0).WithMessage("{PropertyName} is required.");
        }
    }
}
