using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.MakeReaction
{
    public class MakeReactionCommand : IRequest<BaseResponse<ReviewReactionDto>>
    {
        public int ReactionId { get; set; }
        public int ReviewId { get; set; }
        public int ReviewerId { get; set; }
    }
}
