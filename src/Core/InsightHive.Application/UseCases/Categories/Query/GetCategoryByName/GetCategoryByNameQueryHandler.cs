using AutoMapper;
using InsightHive.Application.Exceptions;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{

    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, BaseResponse<CategoryByNameDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByNameQueryHandler(IRepository<Category> categoryRepo, ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CategoryByNameDto>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var categoryName = request.Name;
            var category = await _categoryRepository.GetByNameWithSubCategoriesAsync(categoryName);
            var response = new BaseResponse<CategoryByNameDto>();
            if (category == null)
            {
                throw new NotFoundException($"Category with name '{categoryName}' not found.");

            }
            else
            {
                response.Message = "Category found";
                response.Result = _mapper.Map<CategoryByNameDto>(category);

            }

            return response;
        }
    }
}
