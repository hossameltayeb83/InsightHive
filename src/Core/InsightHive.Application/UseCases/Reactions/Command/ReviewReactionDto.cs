namespace InsightHive.Application.UseCases.Reactions.Command
{
    public class ReviewReactionDto
    {
        public int? ReviewId { get; set; }
        public int ReactionId { get; set; }
        public int ReviewerId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
