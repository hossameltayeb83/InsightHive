namespace InsightHive.Domain.Entities
{
    public class ReviewReaction
    {
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
