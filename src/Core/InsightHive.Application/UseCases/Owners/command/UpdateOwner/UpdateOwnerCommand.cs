using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Owners.command.CreateOwner;
using MediatR;

namespace InsightHive.Application.UseCases.Owners.command.UpdateOwner
{
    public class UpdateOwnerCommand : IRequest<BaseResponse<OwnerDto>>
    {
        public OwnerDto ownerDto { get; set; }
    }
}
