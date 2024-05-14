using InsightHive.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Owners.command.CreateOwner
{
    public class CreateOwnerCommand : IRequest<BaseResponse<OwnerDto>>
    {
        public  OwnerDto ownerDto { get; set; }
    }
}