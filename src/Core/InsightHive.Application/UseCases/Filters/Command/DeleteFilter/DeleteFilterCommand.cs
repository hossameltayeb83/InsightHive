using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Command.DeleteFilter
{
    public class DeleteFilterCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}
