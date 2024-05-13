using FluentValidation;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForCategory
{
    internal class GetAllBusinessesForCategoryQueryValidator : AbstractValidator<GetAllBusinessesForCategoryQuery>
    {
        public GetAllBusinessesForCategoryQueryValidator()
        {
            RuleFor(e => e.Query)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must not be less than 3 characters.");
            RuleFor(e => e.Options)
                 .Matches(@"^(\d*\+?)*$");
        }
    }
}
