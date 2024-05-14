using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Filters.Command.CreateFilter
{
    internal class CreateFilterCommandHandler : IRequestHandler<CreateFilterCommand, BaseResponse<CreateFilterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Filter> _filterRepository;
        private readonly IValidator<CreateFilterCommand> _validator;

        public CreateFilterCommandHandler(IMapper mapper, IRepository<Filter> filterRepository, IValidator<CreateFilterCommand> validator)
        {
            _mapper = mapper;
            _filterRepository = filterRepository;
            _validator = validator;
        }
        public async Task<BaseResponse<CreateFilterDto>> Handle(CreateFilterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CreateFilterDto>();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            var filter = _mapper.Map<Filter>(request);
            bool created = await _filterRepository.AddAsync(filter);
            if (created)
            {
                response.Message = "Filter created successfully.";
                response.Result = _mapper.Map<CreateFilterDto>(filter);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create the Filter.";
            }
            return response;
        }
    }
}
