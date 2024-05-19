using InsightHive.Application.UseCases.Reactions.Command.MakeReaction;
using InsightHive.Application.UseCases.Reactions.Command.RemoveReaction;
using InsightHive.Application.UseCases.Reactions.Command.UpdateReaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("make", Name = "MakeReaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Make([FromBody] MakeReactionCommand makeReactionCmd)
        {
            var response = await _mediator.Send(makeReactionCmd);
            return Ok(response);
        }

        [HttpPut("update", Name = "UpdateReaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateReactionCommand updateReactionCmd)
        {
            var response = await _mediator.Send(updateReactionCmd);
            return Ok(response);
        }

        [HttpDelete("{reviewId}/{reviewerId}", Name = "DeleteReaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int reviewId, int reviewerId)
        {
            //TODO: get reviewerId from token
            var deleteCommand = new RemoveReactionCommand { ReviewId = reviewId, ReviewerId = reviewerId };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
