using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<CategoryDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepo,
                                            IMapper mapper
                                           )
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           // var createCategoryResponse = new CreateCategoryResponse();
            var validator = new CreateCategoryCommandValidator();
            var response = new BaseResponse<CategoryDto>();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            if (response.Success)
            {
                var category = new Category() { Name = request.Name };
                bool isCategoryAdded = await _categoryRepo.AddAsync(category);

                if (isCategoryAdded)
                {
                    response.Result = _mapper.Map<CategoryDto>(category);
                    response.Message = "Category created successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to created the category!";
                }
            }
            return response;

        }

       
    }
}
