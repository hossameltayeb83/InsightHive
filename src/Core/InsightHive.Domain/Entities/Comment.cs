using InsightHive.Domain.Common;

namespace InsightHive.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int? ReviewerId { get; set; }
        public Reviewer? Reviewer { get; set; }

    }
}
