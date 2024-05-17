using FluentValidation;

namespace InsightHive.Application.UseCases.Reactions.Command.MakeReaction
{
    public class MakeReactionCommandValidator : AbstractValidator<MakeReactionCommand>
    {
        public MakeReactionCommandValidator()
        {
            RuleFor(p => p.ReviewId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ReviewerId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ReactionId).GreaterThan(0).WithMessage("{PropertyName} is required.");
        }
    }
}
