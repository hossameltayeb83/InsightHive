namespace InsightHive.Application.UseCases.Reviews.Command.UpdateReview
{
    public class UpdateReviewDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
