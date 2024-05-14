using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.UpdateReviewer
{
    public class UpdateReviewerCommandHandler : IRequestHandler<UpdateReviewerCommand, BaseResponse<UpdateReviewerDto>>
    {
        private readonly IReviewerRepository _reviewerRepo;
        private readonly IValidator<UpdateReviewerCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateReviewerCommandHandler(IReviewerRepository reviewerRepo,
                                            IMapper mapper)
        {
            _reviewerRepo = reviewerRepo;
            _mapper = mapper;
            _validator = new UpdateReviewerCommandValidator();
        }

        public async Task<BaseResponse<UpdateReviewerDto>> Handle(UpdateReviewerCommand request, CancellationToken cancellationToken)
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

            var newReviewer = _mapper.Map<Reviewer>(request);
            bool updated = await _reviewerRepo.UpdateAsync(newReviewer);
            var response = new BaseResponse<UpdateReviewerDto>();

            if (updated)
            {
                response.Message = "Reviewer updated successfully.";
                response.Result = _mapper.Map<UpdateReviewerDto>(newReviewer);
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to updated the reviewer!";
            }
            return response;
        }
    }
}
