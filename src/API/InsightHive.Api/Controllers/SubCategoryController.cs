using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using InsightHive.Application.UseCases.SubCategories.Query;
using InsightHive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
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
