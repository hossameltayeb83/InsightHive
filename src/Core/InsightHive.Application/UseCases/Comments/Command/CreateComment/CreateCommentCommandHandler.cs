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
        private readonly IRepository<Comment> _commentRepo;
        private readonly IValidator<CreateCommentCommand> _validator;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comment> commentRepo,
                                           IMapper mapper)
        {
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

            var commentCreated = await _commentRepo.AddAsync(comment);

            if (!commentCreated)
                return new BaseResponse<CommentDto> { Success = false, Message = "Something went wrong!" };

            return new BaseResponse<CommentDto>
            {
                Message = "Comment created successfully.",
                Result = _mapper.Map<CommentDto>(comment)
            };
        }
    }
}
