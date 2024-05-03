using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepo,
                                            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepo.ListAllAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
    }
}
