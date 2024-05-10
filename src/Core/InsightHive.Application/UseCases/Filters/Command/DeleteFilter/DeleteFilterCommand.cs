using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.DeleteFilter
{
    public class DeleteFilterCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}
