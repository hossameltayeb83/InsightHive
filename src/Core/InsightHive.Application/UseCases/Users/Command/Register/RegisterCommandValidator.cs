using FluentValidation;

namespace InsightHive.Application.UseCases.Users.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.RoleId).GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(e => e.Name).Length(3, 20).WithMessage("name should be between 3 and 20 character!");

            RuleFor(e => e.Email).EmailAddress().WithMessage("invalid email address!");

            //  RuleFor(e => e.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        }
    }
}
