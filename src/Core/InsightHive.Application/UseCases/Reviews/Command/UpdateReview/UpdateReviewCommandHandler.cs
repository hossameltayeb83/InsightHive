using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, BaseResponse<UpdateReviewDto>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IValidator<UpdateReviewCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepo,
                                          IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _validator = new UpdateReviewCommandValidator();
            _mapper = mapper;
        }

        public async Task<BaseResponse<UpdateReviewDto>> Handle(UpdateReviewCommand request,
                                                       CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var review = await _reviewRepo.GetByIdAsync(request.Id);

            if (review == null)
                throw new Exceptions.NotFoundException("Review not found!");

            if (review.ReviewerId != request.ReviewerId)
                throw new Exceptions.NotAuthorizedException("Not authorized to edit this review!");


            var reviewToUpdate = _mapper.Map<Review>(request);
            reviewToUpdate.BusinessId = review.BusinessId;
            bool updated = await _reviewRepo.UpdateAsync(reviewToUpdate);

            var response = new BaseResponse<UpdateReviewDto>();
            if (updated)
            {
                response.Message = "Review updated successfully.";
                response.Result = _mapper.Map<UpdateReviewDto>(reviewToUpdate);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the review!";
            }

            return response;
        }
    }
}
