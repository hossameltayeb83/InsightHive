using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Owners.command.CreateOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Owners.command.UpdateOwner
{
    public class UpdateOwnerCommand:IRequest<BaseResponse<OwnerDto>>
    {
        public OwnerDto ownerDto { get; set; }
    }
}
