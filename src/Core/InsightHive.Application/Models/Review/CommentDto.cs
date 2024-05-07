namespace InsightHive.Application.Models.Review
{
    public class CommentDto
    {
        public int Id { get; init; }
        public int CommenterId { get; init; }
        public string Content { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? LastModifiedDate { get; init; }
    }
}
