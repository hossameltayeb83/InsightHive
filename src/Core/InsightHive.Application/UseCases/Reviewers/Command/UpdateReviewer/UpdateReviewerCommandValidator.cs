using FluentValidation;

namespace InsightHive.Application.UseCases.Reviewers.Command.UpdateReviewer
{
    internal class UpdateReviewerCommandValidator : AbstractValidator<UpdateReviewerCommand>
    {
        public UpdateReviewerCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 Charachers.");

        }
    }
}
