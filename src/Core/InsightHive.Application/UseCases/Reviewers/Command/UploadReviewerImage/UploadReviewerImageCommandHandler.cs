using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage
{
    public class UploadReviewerImageCommandHandler : IRequestHandler<UploadReviewerImageCommand, BaseResponse<string>>
    {
        private readonly IReviewerRepository _reviewerRepo;
        private readonly IValidator<UploadReviewerImageCommand> _validator;
        private readonly IMapper _mapper;

        public UploadReviewerImageCommandHandler(IReviewerRepository reviewerRepo, IMapper mapper)
        {
            _reviewerRepo = reviewerRepo;
            _validator = new UploadReviewerImageCommandValidator();
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> Handle(UploadReviewerImageCommand request, CancellationToken cancellationToken)
        {
            var reviewerToUpdate = await _reviewerRepo.GetByIdAsync(request.Id);
            var user = await _reviewerRepo.GetByUserIdWithUserAsync(request.UserId);

            if (user == null)
                throw new Exceptions.NotAuthorizedException("Not authorized!");

            if (reviewerToUpdate == null)
                throw new Exceptions.NotFoundException("Reviewer not found!");

            if (reviewerToUpdate.Id != user.Id)
                throw new Exceptions.NotAuthorizedException("Not authorized to update this reviewer!");

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            reviewerToUpdate.Image = request.Image;
            bool updated = await _reviewerRepo.UpdateAsync(reviewerToUpdate);
            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "Reviewer image uloaded successfully.";
                response.Result = reviewerToUpdate.Image;
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to uloaded the image!";
            }
            return response;
        }
    }
}
