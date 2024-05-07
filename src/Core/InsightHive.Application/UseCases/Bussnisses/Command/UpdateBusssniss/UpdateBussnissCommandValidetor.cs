using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss
{
    public class UpdateBussnissCommandValidetor : AbstractValidator<UpdateBussnissCommand>
    {
        public UpdateBussnissCommandValidetor()
        {
            RuleFor(p => p.Id)
               .GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Logo)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SubCategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
        }
    }
}
