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

        public UpdateCommentCommandHandler(IRepository<Comment> commentRepo,
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

            comment.Content = request.Content;
            bool updated = await _commentRepo.UpdateAsync(comment);

            if (!updated)

                return new BaseResponse<CommentDto>
                {
                    Success = false,
                    Message = "Failed to update comment!"
                };



            return new BaseResponse<CommentDto>
            {
                Message = "Comment updated successfully.",
                Result = _mapper.Map<CommentDto>(comment)
            };
        }
    }
}
