using InsightHive.Application.Interfaces.Identity;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Users.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<string>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtFactory _jwtFactory;

        public LoginCommandHandler(IUserRepository userRepo,
                                   IJwtFactory jwtFactory)
        {
            _userRepo = userRepo;
            _jwtFactory = jwtFactory;

        }

        public async Task<BaseResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {


            var validPass = await _userRepo.LoginAsync(request.Email, request.Password);

            if (!validPass)
                throw new Exceptions.NotAuthorizedException("Invalid email or password!");

            var user = await _userRepo.GetByEmailAsync(request.Email);

            string token = _jwtFactory.GenerateJwt(user!);

            return new BaseResponse<string> { Message = "Authenticated Successfully.", Result = token };
        }
    }
}
