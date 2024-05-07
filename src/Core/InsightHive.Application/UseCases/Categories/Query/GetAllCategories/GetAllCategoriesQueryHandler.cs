using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.SubCategories.Query;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepo, ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepo = categoryRepo;

            _mapper = mapper;
            _categoryRepository = categoryRepository;

        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllCategoriesWithSubCategoriesAsync();


            var categoryDtos = _mapper.Map<List<CategoryListDto>>(categories);

            foreach (var categoryDto in categoryDtos)
            {
                categoryDto.SubCategories = _mapper.Map<List<SubcategoryDto>>(categoryDto.SubCategories);
            }

            return categoryDtos;
        }
    }
}
