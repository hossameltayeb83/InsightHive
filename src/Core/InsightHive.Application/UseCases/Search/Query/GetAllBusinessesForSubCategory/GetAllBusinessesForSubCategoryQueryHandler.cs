using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSubCategory
{
    internal class GetAllBusinessesForSubCategoryQueryHandler
    {
        private readonly IValidator<GetAllBusinessesForSubCategoryQuery> _validator;
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        public GetAllBusinessesForSubCategoryQueryHandler(IMapper mapper, IBusinessRepository businessRepository)
        {
            _validator = new GetAllBusinessesForSubCategoryQueryValidator();
            _mapper = mapper;
            _businessRepository = businessRepository;
        }
        public async Task<BaseResponse<List<BusinessSearchDto>>> Handle(GetAllBusinessesForSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<BusinessSearchDto>>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            IReadOnlyList<Business> businesses;
            if (request.Options == null && request.Search == null)
            {
                businesses = await _businessRepository.GetAllBySubCategorySearch(request.SubCategoryId, string.Empty, Array.Empty<int>());
            }
            else
            {
                var optionsIds = request.Options?.Split('+').Select(int.Parse).ToArray();
                if (optionsIds != null && request.Search != null)
                {
                    businesses = await _businessRepository.GetAllBySubCategorySearch(request.SubCategoryId, request.Search, optionsIds);
                }
                else if (optionsIds != null)
                {
                    businesses = await _businessRepository.GetAllBySubCategorySearch(request.SubCategoryId, string.Empty, optionsIds);
                }
                else
                {
                    businesses = await _businessRepository.GetAllBySubCategorySearch(request.SubCategoryId, request.Search!, Array.Empty<int>());
                }
            }
            response.Result = _mapper.Map<List<BusinessSearchDto>>(businesses);

            return response;
        }
    }
}
