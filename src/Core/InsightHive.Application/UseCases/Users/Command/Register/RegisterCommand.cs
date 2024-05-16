using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Users.Command.Register
{
    public class RegisterCommand : IRequest<AuthenticationResponse>
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
