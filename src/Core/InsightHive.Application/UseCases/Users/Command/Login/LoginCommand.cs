using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Users.Command.Login
{
    public class LoginCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
