using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Comments.Query.GetCommentDetails;
using InsightHive.Application.UseCases.Reviews.Command.CreateComment;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.DeleteComment;
using InsightHive.Application.UseCases.Reviews.Command.DeleteReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateComment;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
using InsightHive.Application.UseCases.Reviews.Query.GetCommentList;
using InsightHive.Application.UseCases.Reviews.Query.GetReviewDetails;
using InsightHive.Application.UseCases.Reviews.Query.GetReviewList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{commentId}", Name = "GetComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<ReviewDto>>> Get(int commentId)
        {
            var query = new GetCommentDetailsQuery { CommentId = commentId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("paginated/{reviewId}", Name = "GetComments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList(int reviewId, int page = 1, int pageSize = 5, int maxComments = 0)
        {
            var query = new GetCommentListQuery { ReviewId = reviewId, Page = page, PageSize = pageSize };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("add", Name = "AddComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] CreateCommentCommand createCommentCmd)
        {
            var response = await _mediator.Send(createCommentCmd);
            return Ok(response);
        }

        [HttpPut("update", Name = "UpdateComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateCommentCommand updateCommentCmd)
        {
            var response = await _mediator.Send(updateCommentCmd);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            //TODO: get reviewerId from token
            var deleteCommand = new DeleteCommentCommand { Id = id };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
