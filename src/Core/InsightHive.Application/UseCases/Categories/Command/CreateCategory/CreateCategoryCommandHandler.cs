using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<CreateCategoryDto>>
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

        public Task<BaseResponse<CreateCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
