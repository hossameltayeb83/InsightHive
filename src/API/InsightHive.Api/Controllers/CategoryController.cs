using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListDto>>> GetAllCategories()
        {
            var dtos = await _mediatr.Send(new GetAllCategoriesQuery());
            return Ok(dtos);
        }
    }
}
