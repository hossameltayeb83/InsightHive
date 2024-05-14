using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Bussnisses.Query.GetAllBussnies;
using MediatR;

namespace InsightHive.Application.UseCases.Bussnisses.Command.UpdateBusssniss
{
    public class UpdateBussnissCommand : IRequest<BaseResponse<BussniessDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }


    }
}
