using FluentValidation;

namespace InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer
{
    internal class CreateReviewerCommandValidator : AbstractValidator<CreateReviewerCommand>
    {
        public CreateReviewerCommandValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
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
