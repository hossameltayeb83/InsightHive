using InsightHive.Application.Exceptions;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Categories.Query.GetAllCategories;
using InsightHive.Application.UseCases.Categories.Query.GetCategoryById;
using InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName;
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
        [HttpGet("{name}", Name = "GetCategoryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryByNameDto>> GetCategoryByName(string name)
        {
            try
            {
                var response = await _mediatr.Send(new GetCategoryByNameQuery { Name = name });
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("byid/{id}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCategoryByIdDto>> GetCategoryById(int id)
        {
            var response = await _mediatr.Send(new GetCategoryByIdQuery { CategoryId = id });
            if (response == null)
            {
                return NotFound("Category not found");
            }
            return Ok(response);
        }

        [HttpPost("Add", Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryResponse>> AddCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediatr.Send(createCategoryCommand);
            return Ok(response);
        }


    }


}

