using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.MakeReaction
{
    public class MakeReactionCommandHandler : IRequestHandler<MakeReactionCommand, BaseResponse<ReviewReactionDto>>
    {
        private readonly IRepository<ReviewReaction> _reviewReactionRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<MakeReactionCommand> _validator;

        public MakeReactionCommandHandler(IRepository<ReviewReaction> reviewReactionRepo,
                                          IMapper mapper)
        {
            _reviewReactionRepo = reviewReactionRepo;
            _mapper = mapper;
            _validator = new MakeReactionCommandValidator();
        }
        public async Task<BaseResponse<ReviewReactionDto>> Handle(MakeReactionCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var reviewReaction = new ReviewReaction
            {
                ReactionId = request.ReactionId,
                ReviewId = request.ReviewId,
                ReviewerId = request.ReviewId
            };

            var created = await _reviewReactionRepo.AddAsync(reviewReaction);

            return created ?
                 new BaseResponse<ReviewReactionDto>
                 {
                     Message = "Reaction made.",
                     Result = _mapper.Map<ReviewReactionDto>(reviewReaction)
                 } :
                new BaseResponse<ReviewReactionDto>
                {
                    Success = false,
                    Message = "Something went wrong!"
                };
        }
    }
}
