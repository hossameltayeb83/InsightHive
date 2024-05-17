using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Command.CreateBussniss
{
    public class CreateBussnissCommand : IRequest<BaseResponse<BussniessDto>>
    {
        public BussniessDto? bussniessDto { get; set; }
    }
}
