using InsightHive.Domain.Enums;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class ReviewerBadgeDto
    {
        public int Id { get; set; }
        public BadgeName Name { get; set; }
        public string Image { get; set; }
    }
}
