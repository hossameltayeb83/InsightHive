using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Users.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly RegisterCommandValidator _validator;

        public RegisterCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _validator = new RegisterCommandValidator();
        }

        public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var user = _mapper.Map<User>(request);

            return await _userRepo.RegisterAsync(user, request.Password);
        }
    }
}
