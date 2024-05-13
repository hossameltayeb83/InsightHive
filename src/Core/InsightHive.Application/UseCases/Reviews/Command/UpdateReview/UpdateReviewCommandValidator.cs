using FluentValidation;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ReviewerId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Rate)
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be at least 1")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must not exceed 5")
                .Must(rate => rate - Math.Truncate(rate) == 0 || rate - Math.Truncate(rate) == 0.5)
                    .WithMessage("{PropertyValue} is inavlid value for {PropertyName}");
        }
    }
}
