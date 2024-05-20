using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.DeleteReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
using InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails;
using InsightHive.Application.UseCases.Reviews.Query.GetReviewList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{reviewId}", Name = "GetReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<ReviewDto>>> Get(int reviewId, int maxComments = 0)
        {
            var query = new GetReviewDetailsQuery { ReviewId = reviewId, MaxComments = maxComments };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("paginated/{businessId}", Name = "GetBusinessReviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList(int businessId, int page = 1, int pageSize = 5, int maxComments = 0)
        {
            var query = new GetReviewListQuery { BusinessId = businessId, Page = page, PageSize = pageSize, MaxComments = maxComments };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("add", Name = "AddReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<CreateReviewDto>>> Create([FromBody] CreateReviewCommand createRevCmd)
        {
            var response = await _mediator.Send(createRevCmd);
            return Ok(response);
        }

        [HttpPut("update", Name = "UpdateReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<UpdateReviewDto>>> Update([FromBody] UpdateReviewCommand updateRevCmd)
        {
            var response = await _mediator.Send(updateRevCmd);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteReview")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            //TODO: get reviewerId from token
            var deleteCommand = new DeleteReviewCommand { Id = id, ReviewerId = 2 };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
