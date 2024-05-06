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

        public GetCategoryByNameQueryHandler(IRepository<Category> categoryRepo,
                                            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<CategoryByNameDto> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var categoryName = request.Name;
            var category = await _categoryRepo.GetByNameAsync(categoryName);

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
