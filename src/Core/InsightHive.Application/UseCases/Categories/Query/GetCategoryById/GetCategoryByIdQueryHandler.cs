using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, BaseResponse<GetCategoryByIdDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepo, ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<GetCategoryByIdDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdWithSubCategoriesAsync(request.CategoryId);
            if (category == null)
            {
                throw new Exceptions.NotFoundException("categoryId not found");
            }
            var response = new BaseResponse<GetCategoryByIdDto>();
            response.Message = "Category found";
            response.Result = _mapper.Map<GetCategoryByIdDto>(category);
            return response;
        }


    }
}
