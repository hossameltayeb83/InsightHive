using InsightHive.Application.UseCases.SubCategories.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public SubCategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("all", Name = "GetSubCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryWithSubcategoriesDto>>> GetSubCategories([FromQuery] int Id)
        {
            var subCategories = await _mediatr.Send(new GetSubCategoriesListWithCategoryQuery { CategoryId = Id });
            return Ok(subCategories);
        }

    }
}
