using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Owners.command.CreateOwner
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, BaseResponse<OwnerDto>>
    {

        private readonly IRepository<Owner> _ownerRepo;
        private readonly IMapper _mapper;

        public CreateOwnerCommandHandler(IRepository<Owner> ownerRepo,
                                            IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepo = ownerRepo;
        }
        public async Task<BaseResponse<OwnerDto>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var validetor = new CreateOwnerCommandValidetor();
            var validationResult = await validetor.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var response = new BaseResponse<OwnerDto>();
            var NewOwner = _mapper.Map<Owner>(request.ownerDto);
            var created = await _ownerRepo.AddAsync(NewOwner);

            if (created)
            {
                response.Message = "Owner created successfully.";
                response.Result = _mapper.Map<OwnerDto>(NewOwner);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to created the Owner!";
            }
            return response;




        }
    }
}