using FluentValidation;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
