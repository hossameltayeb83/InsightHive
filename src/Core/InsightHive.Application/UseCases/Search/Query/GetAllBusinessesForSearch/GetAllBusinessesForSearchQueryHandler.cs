using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSearch
{
    internal class GetAllBusinessesForSearchQueryHandler : IRequestHandler<GetAllBusinessesForSearchQuery, BaseResponse<List<BusinessSearchDto>>>
    {
        private readonly IValidator<GetAllBusinessesForSearchQuery> _validator;
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        public GetAllBusinessesForSearchQueryHandler(IMapper mapper, IBusinessRepository businessRepository)
        {
            _validator = new GetAllBusinessesForSearchQueryValidator();
            _mapper = mapper;
            _businessRepository = businessRepository;
        }
        public async Task<BaseResponse<List<BusinessSearchDto>>> Handle(GetAllBusinessesForSearchQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<BusinessSearchDto>>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            ///////////////////////////////////
            var businesses =await _businessRepository.GetAllBySearch(request.Search);
            response.Result = _mapper.Map<List<BusinessSearchDto>>(businesses);
            ///////////////////////////////////
            return response;
        }
    }
}
