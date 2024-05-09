using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _CategoryRepo;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IRepository<Category> CategoryRepo,
                                          IMapper mapper)
        {
            _CategoryRepo = CategoryRepo;
            _mapper = mapper;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _CategoryRepo.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exceptions.NotFoundException("Category not found");
            }
            await _CategoryRepo.DeleteAsync(category);
        }
    }
}
