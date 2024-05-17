using FluentValidation;

namespace InsightHive.Application.UseCases.Reactions.Command.UpdateReaction
{
    public class UpdateReactionCommandValidator : AbstractValidator<UpdateReactionCommand>
    {
        public UpdateReactionCommandValidator()
        {
            RuleFor(p => p.ReviewId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ReviewerId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.OldReactionId).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.NewReactionId).GreaterThan(0).WithMessage("{PropertyName} is required.");
        }
    }
}
