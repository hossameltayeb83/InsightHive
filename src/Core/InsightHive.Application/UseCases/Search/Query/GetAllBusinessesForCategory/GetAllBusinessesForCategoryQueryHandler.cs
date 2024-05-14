using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForSearch;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Search.Query.GetAllBusinessesForCategory
{
    internal class GetAllBusinessesForCategoryQueryHandler : IRequestHandler<GetAllBusinessesForCategoryQuery, BaseResponse<List<BusinessSearchDto>>>
    {
        private readonly IValidator<GetAllBusinessesForCategoryQuery> _validator;
        private readonly IMapper _mapper;
        private readonly ISearchRepository _searchRepository;
        public GetAllBusinessesForCategoryQueryHandler( IMapper mapper, ISearchRepository searchRepository)
        {
            _validator = new GetAllBusinessesForCategoryQueryValidator();
            _mapper = mapper;
            _searchRepository = searchRepository;
        }
        public async Task<BaseResponse<List<BusinessSearchDto>>> Handle(GetAllBusinessesForCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<BusinessSearchDto>>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            ///////////////////////////////////
            var optionsIds = request.Options.Split('+').Select(int.Parse).ToArray();
            var businesses = await _searchRepository.GetAllByCategorySearch(request.CategoryId,request.Query, optionsIds);
            response.Result = _mapper.Map<List<BusinessSearchDto>>(businesses);
            ///////////////////////////////////
            return response;
        }
    }
}
