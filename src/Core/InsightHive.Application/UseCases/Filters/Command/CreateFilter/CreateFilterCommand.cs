using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.CreateFilter
{
    public class CreateFilterCommand : IRequest<BaseResponse<CreateFilterDto>>
    {
        public string Name { get; set; }
        public ICollection<CreateOptionDto> Options { get; set; }
    }
}
