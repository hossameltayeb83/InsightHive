using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Application.UseCases.Categories.Command.CreateCategory;
using InsightHive.Application.UseCases.Filters.Command.CreateFilter;
using InsightHive.Application.UseCases.Filters.Command.UpdateFilter;
using InsightHive.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Filters.Command.UpdateFilter
{
    internal class UpdateFilterCommandHandler : IRequestHandler<UpdateFilterCommand, BaseResponse<UpdateFilterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Filter> _filterRepository;
        private readonly IValidator<UpdateFilterCommand> _validator;

        public UpdateFilterCommandHandler(IMapper mapper, IRepository<Filter> filterRepository,IValidator<UpdateFilterCommand> validator)
        {

            _mapper = mapper;
            _filterRepository = filterRepository;
            _validator = validator;
        }
        public async Task<BaseResponse<UpdateFilterDto>> Handle(UpdateFilterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UpdateFilterDto>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            var filter = _mapper.Map<Filter>(request);
            bool created=await _filterRepository.UpdateAsync(filter);
            if (created)
            {
                response.Message = "Filter updated successfully.";
                response.Result= _mapper.Map<UpdateFilterDto>(filter);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the Filter.";
            }
            return response;
        }
    }
}
