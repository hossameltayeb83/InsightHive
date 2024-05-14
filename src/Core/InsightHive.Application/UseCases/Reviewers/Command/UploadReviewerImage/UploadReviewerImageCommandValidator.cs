using FluentValidation;

namespace InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage
{
    internal class UploadReviewerImageCommandValidator : AbstractValidator<UploadReviewerImageCommand>
    {
        public UploadReviewerImageCommandValidator()
        {
            RuleFor(e => e.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} Max lenght is 50.");
        }

    }
}
