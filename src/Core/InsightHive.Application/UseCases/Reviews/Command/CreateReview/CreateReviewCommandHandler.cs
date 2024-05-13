using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, BaseResponse<CreateReviewDto>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IValidator<CreateReviewCommand> _validator;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepo,
                                          IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _validator = new CreateReviewCommandValidator();
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateReviewDto>> Handle(CreateReviewCommand request,
                                                 CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var review = _mapper.Map<Review>(request);
            var response = new BaseResponse<CreateReviewDto>();
            bool created = await _reviewRepo.AddReviewAsync(review);

            if (created)
            {
                response.Message = "Review created successfully.";
                response.Result = _mapper.Map<CreateReviewDto>(review);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create the review!";
            }

            return response;
        }
    }
}
