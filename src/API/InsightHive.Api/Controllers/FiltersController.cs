using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Command.CreateFilter;
using InsightHive.Application.UseCases.Filters.Command.DeleteFilter;
using InsightHive.Application.UseCases.Filters.Command.UpdateFilter;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Application.UseCases.Filters.Query.GetAllFilters;
using InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForCategory;
using InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForSubCategory;
using InsightHive.Application.UseCases.Filters.Query.GetFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiltersController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public FiltersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(List<FilterDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilter([FromRoute] GetFilterQuery query)
        {
            var filter = await _mediatr.Send(query);
            return Ok(filter);
        }
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<FilterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFilters()
        {
            var filters = await _mediatr.Send(new GetAllFiltersQuery());
            return Ok(filters);
        }
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<CreateFilterDto>),StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateFilter(CreateFilterCommand command)
        {
            var response = await _mediatr.Send(command);
            return CreatedAtRoute(response.Result.Id,response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(BaseResponse<List<UpdateFilterDto>>), StatusCodes.Status200OK)]      
        public async Task<IActionResult> UpdateFilter(UpdateFilterCommand command)
        {
            var response = await _mediatr.Send(command);       
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFilter([FromRoute] DeleteFilterCommand command)
        {
            var response = await _mediatr.Send(command);
            return Ok(response);
        }
        [HttpGet("/api/Categories/{CategoryId:int}/filters")]
        [ProducesResponseType(typeof(BaseResponse<List<FilterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFiltersByCategory([FromRoute] GetAllFiltersForCategoryQuery query)
        {
            var response = await _mediatr.Send(query);
            return Ok(response);
        }
        [HttpGet("/api/SubCategories/{SubCategoryId:int}/filters")]
        [ProducesResponseType(typeof(BaseResponse<List<FilterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFiltersBySubCategory([FromRoute] GetAllFiltersForSubCategoryQuery query)
        {
            var response = await _mediatr.Send(query);
            return Ok(response);
        }
    }
}
