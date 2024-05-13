using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.CreateFilter
{
    internal class CreateFilterCommandValidator :AbstractValidator<CreateFilterCommand>
    {
        public CreateFilterCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must not be less than 3 characters.");
            RuleForEach(e => e.Options)
                .ChildRules(option =>
                {
                    option.RuleFor(o=>o.Content)
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
