﻿using FluentValidation;

namespace InsightHive.Application.UseCases.Filters.Command.UpdateFilter
{
    internal class UpdateFilterCommandValidator : AbstractValidator<UpdateFilterCommand>
    {
        public UpdateFilterCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must not be less than 3 characters.");
            RuleForEach(e => e.Options)
                .ChildRules(option =>
                {
                    option.RuleFor(o => o.Content)
                            .NotEmpty().WithMessage("{PropertyName} is required.")
                            .NotNull()
                            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
                            .MinimumLength(3).WithMessage("{PropertyName} must not be less than 3 characters.");
                });
            RuleFor(e => e.Options)
                .NotEmpty().WithMessage("{propertyName} is required");

        }
    }
}
