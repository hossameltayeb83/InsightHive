using InsightHive.Application.UseCases.Users.Command.Login;
using InsightHive.Application.UseCases.Users.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login(LoginCommand loginCmd)
        {
            var result = await _mediator.Send(loginCmd);
            return Ok(result);
        }

        [HttpPost("register", Name = "Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(RegisterCommand registerCmd)
        {
            var result = await _mediator.Send(registerCmd);
            return Ok(result);
        }
    }
}
