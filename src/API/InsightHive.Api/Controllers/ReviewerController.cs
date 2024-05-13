using Azure;
using InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.DeleteReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage;
using InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers;
using InsightHive.Application.UseCases.Reviewers.Query.GetReviewer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly string _path = @"wwwroot\Images\";

        public ReviewerController(IMediator mediatr)
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
        public async Task<IActionResult> UploadProfileImage(IFormFile formFile, UploadReviewerImageCommand command)
        {               
            string fileExe = formFile.FileName.Split('.').Last();
            string imagePath = $"Reviewer\\{command.Id}_img.{fileExe}";
            string fullPath = _path+imagePath; 
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            using (FileStream stream = System.IO.File.Create(fullPath))
            {
                await formFile.CopyToAsync(stream);
            }
            Console.WriteLine("successful upload ! " +imagePath);
            var response = await _mediatr.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReviewer([FromRoute] DeleteReviewerCommand command)
        {
            await _mediatr.Send(command);
            return NoContent();
        }
    }
}
