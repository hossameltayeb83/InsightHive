using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPut("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(IFormFile formFile, int Id)
        {
            try
            {                
                string fileExe = formFile.FileName.Split('.').Last();
                string imagePath = $"Reviewer\\{Id}_img.{fileExe}";
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
                //send request to mediator to save imagePath
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Ok();
        }
    }
}
