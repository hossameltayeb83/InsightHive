﻿using FluentValidation;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory
{
    internal class GetAllBusinessesForSubCategoryQueryValidator : AbstractValidator<GetAllBusinessesForSubCategoryQuery>
    {
        public GetAllBusinessesForSubCategoryQueryValidator()
        {
            RuleFor(e => e.Search)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must not be less than 3 characters.");
            RuleFor(e => e.Options)
                 .Matches(@"^(\d*\+?)*$");
        }
    }
}
