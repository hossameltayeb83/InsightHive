using FluentValidation;

namespace InsightHive.Application.UseCases.Owners.command.UpdateOwner
{
    public class UpdateOwnerCommandValidetor : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidetor()
        {
            RuleFor(p => p.ownerDto)
               .NotNull().WithMessage("Owner details are required.");

            RuleFor(p => p.ownerDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.ownerDto.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(p => p.ownerDto.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters long.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .Matches("[0-9]").WithMessage("{PropertyName} must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("{PropertyName} must contain at least one special character.");


            RuleFor(p => p.ownerDto.BussnissName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}