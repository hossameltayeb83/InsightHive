namespace InsightHive.Application.Models.Review
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int CommenterId { get; init; }
        public int ReviewId { get; init; }
        public string Content { get; init; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; init; }
    }
}
