using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
