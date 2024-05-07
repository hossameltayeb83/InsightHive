using InsightHive.Domain.Enums;

namespace InsightHive.Application.Models.Review
{
    public class ReviewDto
    {
        public int Id { get; init; }
        public string Content { get; init; }
        public float Rate { get; init; }
        public string? Image { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? LastModifiedDate { get; init; }
        public IReadOnlyCollection<CommentDto> ReviewComments { get; set; }
        public Dictionary<ReactionValue, int> ReactionsCount { get; }
    }
}
