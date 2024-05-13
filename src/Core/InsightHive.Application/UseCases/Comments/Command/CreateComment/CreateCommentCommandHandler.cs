using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Models.Review;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseResponse<CommentDto>>
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IRepository<Comment> _commentRepo;
        private readonly IValidator<CreateCommentCommand> _validator;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IReviewRepository reviewRepo,
                                           IRepository<Comment> commentRepo,
                                           IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _commentRepo = commentRepo;
            _validator = new CreateCommentCommandValidator();
            _mapper = mapper;
        }

        public async Task<BaseResponse<CommentDto>> Handle(CreateCommentCommand request,
                                                 CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var comment = _mapper.Map<Comment>(request);

            var response = new BaseResponse<CommentDto>();
            var commentCreated = await _commentRepo.AddAsync(comment);

            if (!commentCreated)
            {
                response.Success = false;
                response.Message = "Something went wrong!";
                return response;
            }

            var reviewComment = _mapper.Map<ReviewComment>(request);
            reviewComment.CommentId = comment.Id;
            bool reviewCommentCreated = await _reviewRepo.AddReviewCommentAsync(reviewComment);

            if (reviewCommentCreated)
            {
                response.Message = "Comment created successfully.";
                var commentDto = _mapper.Map<CommentDto>(request);
                commentDto.Id = comment.Id;
                commentDto.CreatedDate = comment.CreatedDate;
                response.Result = commentDto;
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create the comment!";
            }

            return response;
        }
    }
}
