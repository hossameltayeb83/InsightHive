using FluentValidation;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.CommenterId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ReviewId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
