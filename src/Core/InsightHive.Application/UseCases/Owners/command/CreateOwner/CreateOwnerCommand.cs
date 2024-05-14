using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Owners.command.CreateOwner
{
    public class CreateOwnerCommand : IRequest<BaseResponse<OwnerDto>>
    {
        public OwnerDto ownerDto { get; set; }
    }
}