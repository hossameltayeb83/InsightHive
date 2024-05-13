using InsightHive.Domain.Enums;

namespace InsightHive.Domain.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public ReactionValue Name { get; set; }
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();
    }
}
