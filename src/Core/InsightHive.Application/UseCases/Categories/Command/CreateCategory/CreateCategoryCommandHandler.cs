using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryCommand> _validator;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepo,
                                            IMapper mapper,
                                            IValidator<CreateCategoryCommand> validator)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryResponse = new CreateCategoryResponse();

            var category = new Category() { Name = request.Name };
            bool isCategoryAdded = await _categoryRepo.AddAsync(category);

            if (isCategoryAdded)
            {
                createCategoryResponse.CategoryDto = _mapper.Map<CreateCategoryDto>(category);
                createCategoryResponse.Success = true;
            }
            
            return createCategoryResponse;
        }
    }
}
