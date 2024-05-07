using InsightHive.Domain.Enums;

namespace InsightHive.Domain.Entities
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Badge> Badges { get; set; } = new HashSet<Badge>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<ReviewComment> ReviewComments { get; set; } = new HashSet<ReviewComment>();
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();

    }
}
