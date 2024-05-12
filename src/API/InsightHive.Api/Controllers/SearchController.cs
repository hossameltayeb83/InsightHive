using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Filters.Query.Dtos;
using InsightHive.Application.UseCases.Filters.Query.GetAllFilters;
using InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForCategory;
using InsightHive.Application.UseCases.Filters.Query.GetAllFiltersForSubCategory;
using InsightHive.Application.UseCases.Search.Query;
using InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForCategory;
using InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSearch;
using InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory;
using InsightHive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace InsightHive.Api.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public SearchController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("api/businesses/Search")]
        public async Task<IActionResult> GetAllBusinessesBySearch([FromQuery]GetAllBusinessesForSearchQuery query)
        {
            var businesses = await _mediatr.Send(query);
            return Ok(businesses);
        }
        [HttpGet("/api/Categories/{CategoryId:int}/businesses")]
        [ProducesResponseType(typeof(BaseResponse<List<FilterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBuisnessesByCategory(int categoryId, string? query,string? options)
        {
            var response = await _mediatr.Send(new GetAllBusinessesForCategoryQuery { CategoryId= categoryId,Query=query, Options=options });
            return Ok(response);
        }
        [HttpGet("/api/SubCategories/{SubCategoryId:int}/businesses")]
        [ProducesResponseType(typeof(BaseResponse<List<FilterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFiltersBySubCategory(int subCategoryId, string? query, string? options)
        {
            var response = await _mediatr.Send(new GetAllBusinessesForSubCategoryQuery { SubCategoryId = subCategoryId, Query = query, Options = options });
            return Ok(response);
        }
    }
   
}
