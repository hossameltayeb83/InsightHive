using FluentValidation;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(p => p.ReviewerId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.BusinessId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.Rate)
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be at least 1")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must not exceed 5")
                .Must(rate => rate - Math.Truncate(rate) == 0 || rate - Math.Truncate(rate) == 0.5)
                    .WithMessage("{PropertyValue} is inavlid value for {PropertyName}");
        }
    }
}
