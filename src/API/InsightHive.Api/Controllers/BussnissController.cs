using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss;
using InsightHive.Application.UseCases.Bussnisses.Command.DeleteBussniss;
using InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using InsightHive.Application.UseCases.Bussnisses.Query.GetBussnissById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsightHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussnissController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public BussnissController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("all", Name = "GetAllBussnisses")]
        public async Task<ActionResult<List<BussniessDto>>> GetAllBussnisses()
        {
            var bussnisses = await _mediatr.Send(new GetAllBussniessQuery());
            return Ok(bussnisses);
        }
        [HttpDelete("{id}", Name = "DeleteBussniss")]
        public async Task<ActionResult> DeleteBussniss(int id)
        {
            var deleteBussnissCommand = new DeleteBussnissCommand() { Id = id };
            await _mediatr.Send(deleteBussnissCommand);
            return NoContent();
        }
        [HttpPut(Name = "UpdateBussniss")]
        public async Task<ActionResult<BaseResponse<BussniessDto>>> UpdateBussniss([FromBody] UpdateBussnissCommand updateBussnissCommand)
        {
            var businessUpdated = await _mediatr.Send(updateBussnissCommand);
            return Ok(businessUpdated);
        }
        [HttpPost(Name = "CreateBussniss")]
        public async Task<ActionResult<BaseResponse<BussniessDto>>> createBussniss([FromBody] CreateBussnissCommand createBussnissCommand)
        {
            var bussnissresult = await _mediatr.Send(createBussnissCommand);
            return Created("BussnissCreated", bussnissresult);
        }
        [HttpGet("{id}", Name = "GetbussnissById")]
        public async Task<ActionResult<BussniessDto>> GetbussnissById(int id)
        {
            var bussnissresult = await _mediatr.Send(new GetBussnissByIdQuery { Id = id });
            return Ok(bussnissresult);

        }

    }
}
