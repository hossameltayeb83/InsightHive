using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using MediatR;

namespace InsightHive.Application.UseCases.SubCategories.Query
{
    public class GetSubCategoriesListWithCategoryQueryHandler : IRequestHandler<GetSubCategoriesListWithCategoryQuery, CategoryWithSubcategoriesDto>
    {
        private readonly ISubCategoryRepository _subCategory;
        private readonly IMapper _mapper;

        public GetSubCategoriesListWithCategoryQueryHandler(ISubCategoryRepository subCategory,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _subCategory = subCategory;
        }
        public async Task<CategoryWithSubcategoriesDto> Handle(GetSubCategoriesListWithCategoryQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategory.GetByCategoryIdAsync(request.CategoryId);
            var categoryWithSubcategoriesDto = new CategoryWithSubcategoriesDto
            {
                CategoryId = request.CategoryId
            };
            if (subCategories != null && subCategories.Count > 0)
            {
                categoryWithSubcategoriesDto.Subcategories = _mapper.Map<List<SubcategoryDto>>(subCategories);
                categoryWithSubcategoriesDto.CategoryName = subCategories[0].Category.Name;

            }

            return categoryWithSubcategoriesDto;
        }

    }
}
