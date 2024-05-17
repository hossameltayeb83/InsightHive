using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.RemoveReaction
{
    public class RemoveReactionCommand : IRequest
    {
        public int ReviewId { get; set; }
        public int ReviewerId { get; set; }
    }
}
