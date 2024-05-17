using FluentValidation;
using InsightHive.Application.UseCases.Categories.Command.UpdateCategory;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class UpdateCategoryCommendValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommendValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .Matches("^[a-zA-Z]*$").WithMessage("{PropertyName} must contain only letters.")
               .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
        }
    }
}
