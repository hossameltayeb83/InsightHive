using FluentValidation;

namespace InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss
{
    public class CreateBussnissCommandValidetor : AbstractValidator<CreateBussnissCommand>
    {
        public CreateBussnissCommandValidetor()
        {
            RuleFor(p => p.bussniessDto)
                .NotNull().WithMessage("Business details are required.");

            RuleFor(p => p.bussniessDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.bussniessDto.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.bussniessDto.Logo)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.bussniessDto.SubCategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.bussniessDto.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.bussniessDto.OwnerId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");
        }
    }
}

