using InsightHive.Domain.Enums;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.MakeReaction
{
    public class MakeReactionCommand : IRequest
    {
        public int ReviewId { get; set; }
        public ReactionValue Reaction { get; set; }
    }
}
