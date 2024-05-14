using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse<CategoryDto>>
    {

        private readonly IRepository<Category> _CategoryRepo;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> CategoryRepo,
                                          IMapper mapper)
        {
            _CategoryRepo = CategoryRepo;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _CategoryRepo.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new Exceptions.NotFoundException("Category not found!");
            }
            var validator = new UpdateCategoryCommendValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var categoryToUpdate = _mapper.Map<Category>(request);
            categoryToUpdate.Id = category.Id;
            bool updated = await _CategoryRepo.UpdateAsync(categoryToUpdate);

            var response = new BaseResponse<CategoryDto>();
            if (updated)
            {
                response.Message = "Category updated successfully.";
                response.Result = _mapper.Map<CategoryDto>(categoryToUpdate);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the category!";
            }

            return response;
        }
    }
}

