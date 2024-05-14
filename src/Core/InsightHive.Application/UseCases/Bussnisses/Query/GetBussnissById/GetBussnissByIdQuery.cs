using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetBussnissById
{
    public class GetBussnissByIdQuery : IRequest<BaseResponse<BussniessDto>>
    {
        public int Id { get; set; }
    }
}
