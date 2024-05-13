using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.UpdateReaction
{
    public class UpdateReactionCommandHandler : IRequestHandler<UpdateReactionCommand, BaseResponse<ReviewReactionDto>>
    {
        private readonly IValidator<UpdateReactionCommand> _validator;
        private readonly IReviewReactionRepository _reviewReactoinRepo;
        private readonly IMapper _mapper;

        public UpdateReactionCommandHandler(IReviewReactionRepository reviewReactoinRepo,
                                            IMapper mapper)
        {
            _validator = new UpdateReactionCommandValidator();
            _reviewReactoinRepo = reviewReactoinRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ReviewReactionDto>> Handle(UpdateReactionCommand request,
                                                           CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var reaction = await _reviewReactoinRepo.GetByIdAsync(request.ReviewId, request.OldReactionId, request.ReviewerId);

            if (reaction == null)
                throw new Exceptions.NotFoundException("Reaction not found!");

            // TODO: authorize before update
            //if (comment.ReviewerId != request.CommenterId)
            //    throw new Exceptions.NotAuthorizedException("Not authorized to edit this comment!");

            reaction.ReactionId = request.NewReactionId;
            bool updated = await _reviewReactoinRepo.UpdateAsync(reaction);

            return updated ?
                 new BaseResponse<ReviewReactionDto>
                 {
                     Message = "Comment updated successfully.",
                     Result = _mapper.Map<ReviewReactionDto>(reaction)
                 } :
                new BaseResponse<ReviewReactionDto>
                {
                    Success = false,
                    Message = "Failed to update comment!"
                };
        }
    }
}
