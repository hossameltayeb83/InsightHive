using AutoMapper;
using InsightHive.Application.Exceptions;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Query.GetCtegoryByName
{

    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, CategoryByNameDto>
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
        public async Task<CategoryByNameDto> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var categoryName = request.Name;
            var category = await _categoryRepository.GetByNameWithSubCategoriesAsync(categoryName);

            if (category != null)
            {
                var categoryDto = _mapper.Map<CategoryByNameDto>(category);
                return categoryDto;
            }
            else
            {
                throw new NotFoundException($"Category with name '{categoryName}' not found.");
            }
        }
    }
}
