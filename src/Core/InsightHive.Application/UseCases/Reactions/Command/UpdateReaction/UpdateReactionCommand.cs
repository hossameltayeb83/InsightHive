using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.UpdateReaction
{
    public class UpdateReactionCommand : IRequest<BaseResponse<ReviewReactionDto>>
    {
        public int NewReactionId { get; set; }
        public int OldReactionId { get; set; }
        public int ReviewId { get; set; }
        public int ReviewerId { get; set; }
    }
}
