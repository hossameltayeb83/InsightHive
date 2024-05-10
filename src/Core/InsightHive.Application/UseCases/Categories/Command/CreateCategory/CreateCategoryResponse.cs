using InsightHive.Application.Responses;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryResponse : BaseResponse<CreateCategoryDto>
    {
        public CreateCategoryDto? CategoryDto { get; set; }
    }
}
