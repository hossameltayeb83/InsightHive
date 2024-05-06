﻿using AutoMapper;
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
        private readonly IRepository<SubCategory> _SubcategoryRepo;
        private readonly ISubCategoryRepo _subCategory;
        private readonly IMapper _mapper;

        public GetSubCategoriesListWithCategoryQueryHandler(IRepository<SubCategory> SubcategoryRepo, ISubCategoryRepo subCategory,
                                            IMapper mapper)
        {
            _SubcategoryRepo = SubcategoryRepo;
            _mapper = mapper;
            _subCategory = subCategory;
        }
        public async Task<CategoryWithSubcategoriesDto> Handle(GetSubCategoriesListWithCategoryQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategory.GetByCategoryIdAsync(request.CategoryId);
            var categoryWithSubcategoriesDto = new CategoryWithSubcategoriesDto
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName, 
                Subcategories = _mapper.Map<List<SubcategoryDto>>(subCategories)
            };
            return categoryWithSubcategoriesDto;
        }

    }
}
