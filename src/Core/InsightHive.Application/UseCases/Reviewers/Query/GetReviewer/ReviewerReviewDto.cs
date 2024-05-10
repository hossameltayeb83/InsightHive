

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class ReviewerReviewDto
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
    }
}
