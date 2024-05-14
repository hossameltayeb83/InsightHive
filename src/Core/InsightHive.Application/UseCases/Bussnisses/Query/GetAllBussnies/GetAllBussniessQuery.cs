using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies
{
    public class GetAllBussniessQuery : IRequest<BaseResponse<List<BussniessDto>>>
    {

    }
}
