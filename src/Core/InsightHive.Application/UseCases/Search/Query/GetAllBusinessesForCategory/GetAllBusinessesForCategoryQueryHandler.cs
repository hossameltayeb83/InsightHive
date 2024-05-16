using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForCategory
{
    internal class GetAllBusinessesForCategoryQueryHandler : IRequestHandler<GetAllBusinessesForCategoryQuery, BaseResponse<List<BusinessSearchDto>>>
    {
        private readonly IValidator<GetAllBusinessesForCategoryQuery> _validator;
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        public GetAllBusinessesForCategoryQueryHandler( IMapper mapper, IBusinessRepository businessRepository)
        {
            _validator = new GetAllBusinessesForCategoryQueryValidator();
            _mapper = mapper;
            _businessRepository = businessRepository;
        }
        public async Task<BaseResponse<List<BusinessSearchDto>>> Handle(GetAllBusinessesForCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<BusinessSearchDto>>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            IReadOnlyList<Business> businesses;
            if (request.Options == null && request.Query == null)
            {
                businesses = await _businessRepository.GetAllByCategorySearch(request.CategoryId,string.Empty,Array.Empty<int>());
            }
            else  
            {
                var optionsIds = request.Options?.Split('+').Select(int.Parse).ToArray();
                if(optionsIds!=null&&request.Query != null)
                {
                    businesses = await _businessRepository.GetAllByCategorySearch(request.CategoryId,request.Query,optionsIds);
                }
                else if (optionsIds!= null)
                {
                    businesses = await _businessRepository.GetAllByCategorySearch(request.CategoryId,string.Empty, optionsIds);
                }
                else  
                {
                    businesses = await _businessRepository.GetAllByCategorySearch(request.CategoryId, request.Query!,Array.Empty<int>());
                }
            }
            response.Result = _mapper.Map<List<BusinessSearchDto>>(businesses);
            return response;
        }
    }
}
