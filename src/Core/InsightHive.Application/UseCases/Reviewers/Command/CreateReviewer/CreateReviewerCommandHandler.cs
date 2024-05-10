using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;


namespace InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer
{
    public class CreateReviewerCommandHandler : IRequestHandler<CreateReviewerCommand, BaseResponse<CreateReviewerDto>>
    {
        private readonly IReviewerRepository _reviewerRepo;
        private readonly IValidator<CreateReviewerCommand> _validator;
        private readonly IMapper _mapper;

        public CreateReviewerCommandHandler(IReviewerRepository reviewerRepo,
                                            IMapper mapper)
        {
            _reviewerRepo = reviewerRepo;
            _mapper = mapper;
            _validator = new CreateReviewerCommandValidator();
        }

        public async Task<BaseResponse<CreateReviewerDto>> Handle(CreateReviewerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var reviewer = _mapper.Map<Reviewer>(request);
            bool created = await _reviewerRepo.AddAsync(reviewer);
            var response = new BaseResponse<CreateReviewerDto>();

            if(created)
            {
                response.Message = "Reviewer created successfully.";
                response.Result = _mapper.Map<CreateReviewerDto>(reviewer);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to created the reviewer!";
            }
            return response;

        }
    }
}
