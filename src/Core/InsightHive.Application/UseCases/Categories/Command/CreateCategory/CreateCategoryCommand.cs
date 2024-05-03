using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}