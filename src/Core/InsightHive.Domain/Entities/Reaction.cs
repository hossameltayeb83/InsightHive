using InsightHive.Domain.Enums;

namespace InsightHive.Domain.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public ReactionValue ReactionType { get; set; }
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();
    }
}
