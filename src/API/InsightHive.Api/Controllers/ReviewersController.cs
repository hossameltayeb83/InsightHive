using InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.DeleteReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage;
using InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers;
using InsightHive.Application.UseCases.Reviewers.Query.GetReviewer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly string _path = @"wwwroot\Images\";

        public ReviewersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReviewer([FromRoute] GetReviewerQuery query)
        {
            var reviewer = await _mediatr.Send(query);
            return Ok(reviewer);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReviewers([FromRoute] GetAllReviewersQuery query)
        {
            var reviewers = await _mediatr.Send(query);
            return Ok(reviewers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReviewer([FromRoute] CreateReviewerCommand command)
        {
            var reviewer = await _mediatr.Send(command);
            return Ok(reviewer);
        }
        [HttpPut]
        public async Task<IActionResult> updateReviewer([FromRoute] GetAllReviewersQuery query)
        {
            var reviewer = await _mediatr.Send(query);
            return Ok(reviewer);
        }

        [HttpPut("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(int Id , int UserId,IFormFile formFile)
        {
            UploadReviewerImageCommand command = new UploadReviewerImageCommand() { Id = Id, UserId = UserId };
            string fileExe = formFile.FileName.Split('.').Last();
            string imagePath = $"Reviewer\\{command.Id}_img.{fileExe}";
            string fullPath = _path + imagePath;
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            using (FileStream stream = System.IO.File.Create(fullPath))
            {
                await formFile.CopyToAsync(stream);
            }
            Console.WriteLine("successful upload ! " +imagePath);
            command.Image = imagePath;
            var response = await _mediatr.Send(command);
            return Ok(imagePath);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReviewer([FromRoute] DeleteReviewerCommand command)
        {
            await _mediatr.Send(command);
            return NoContent();
        }
    }
}
