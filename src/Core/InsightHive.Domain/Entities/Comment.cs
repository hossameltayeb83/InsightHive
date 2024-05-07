using InsightHive.Domain.Common;

namespace InsightHive.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public ICollection<ReviewComment> ReviewComments { get; set; } = new HashSet<ReviewComment>();

    }
}
