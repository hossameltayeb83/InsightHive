using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Command.CreateFilter
{
    public class CreateFilterCommand : IRequest<BaseResponse<CreateFilterDto>>
    {
        public string Name { get; set; }
        public ICollection<CreateOptionDto> Options { get; set; }
    }
}
