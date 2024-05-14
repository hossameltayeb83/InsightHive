using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<BaseResponse<CategoryDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
