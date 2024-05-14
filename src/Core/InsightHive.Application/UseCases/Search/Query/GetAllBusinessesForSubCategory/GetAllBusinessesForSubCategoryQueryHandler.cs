using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory
{
    internal class GetAllBusinessesForSubCategoryQueryHandler
    {
        private readonly IValidator<GetAllBusinessesForSubCategoryQuery> _validator;
        private readonly IMapper _mapper;
        private readonly ISearchRepository _searchRepository;
        public GetAllBusinessesForSubCategoryQueryHandler(IMapper mapper, ISearchRepository searchRepository)
        {
            _validator = new GetAllBusinessesForSubCategoryQueryValidator();
            _mapper = mapper;
            _searchRepository = searchRepository;
        }
        public async Task<BaseResponse<List<BusinessSearchDto>>> Handle(GetAllBusinessesForSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<BusinessSearchDto>>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var optionsIds = request.Options.Split('+').Select(int.Parse).ToArray();
            var businesses = await _searchRepository.GetAllBySubCategorySearch(request.Query, optionsIds);
            response.Result = _mapper.Map<List<BusinessSearchDto>>(businesses);

            return response;
        }
    }
}
