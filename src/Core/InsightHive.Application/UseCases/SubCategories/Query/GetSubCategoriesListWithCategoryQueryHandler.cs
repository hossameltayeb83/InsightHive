using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.SubCategories.Query
{
    public class GetSubCategoriesListWithCategoryQueryHandler : IRequestHandler<GetSubCategoriesListWithCategoryQuery, CategoryWithSubcategoriesDto>
    {
        private readonly ISubCategoryRepo _subCategory;
        private readonly IMapper _mapper;

        public GetSubCategoriesListWithCategoryQueryHandler( ISubCategoryRepo subCategory,
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
