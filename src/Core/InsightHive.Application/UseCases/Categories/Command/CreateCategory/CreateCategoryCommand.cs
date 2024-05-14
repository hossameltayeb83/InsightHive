using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<BaseResponse<CategoryDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}