using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<BaseResponse<CreateCategoryDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}