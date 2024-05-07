using InsightHive.Application.UseCases.Owners.command.CreateOwner;
using InsightHive.Application.UseCases.Owners.command.UpdateOwner;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public OwnerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpPost(Name = "CreateOwner")]
        public async Task<ActionResult> CreateOwner([FromBody]CreateOwnerCommand createOwnerCommand)
        {
            var owner = await _mediatr.Send(createOwnerCommand);
            return Ok(owner);   
        }
        [HttpPut(Name = "UpdateOwner")]
        public async Task<ActionResult> UpdateOwner([FromBody] UpdateOwnerCommand updateOwnerCommand)
        {
            await _mediatr.Send(updateOwnerCommand);
            return Ok("updated owner");
        }


}
    }
