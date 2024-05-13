using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseResponse<CommentDto>>
    {
        private readonly IRepository<Comment> _commentRepo;
        private readonly IValidator<UpdateCommentCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IReviewRepository reviewRepo,
                                           IRepository<Comment> commentRepo,
                                           IMapper mapper)
        {
            _commentRepo = commentRepo;
            _validator = new UpdateCommentCommandValidator();
            _mapper = mapper;
        }

        public async Task<BaseResponse<CommentDto>> Handle(UpdateCommentCommand request,
                                                           CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var comment = await _commentRepo.GetByIdAsync(request.Id);

            if (comment == null)
                throw new Exceptions.NotFoundException("Comment not found!");

            // TODO: authorize before update
            //if (comment.ReviewerId != request.CommenterId)
            //    throw new Exceptions.NotAuthorizedException("Not authorized to edit this comment!");

            var commentToUpdate = _mapper.Map<Comment>(request);
            bool updated = await _commentRepo.UpdateAsync(commentToUpdate);

            var response = new BaseResponse<CommentDto>();
            if (updated)
            {
                response.Message = "Review updated successfully.";
                // TODO: return CommentDto
                //response.Result = _mapper.Map<CommentDto>(commentToUpdate);
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
