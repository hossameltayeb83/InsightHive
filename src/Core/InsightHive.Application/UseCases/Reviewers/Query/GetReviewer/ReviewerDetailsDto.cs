using InsightHive.Domain.Enums;


namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class ReviewerDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public ICollection<ReviewerBadgeDto> Badges { get; set; } = new HashSet<ReviewerBadgeDto>();
        public ICollection<ReviewerReviewDto> Reviews { get; set; } = new HashSet<ReviewerReviewDto>();
    }
}
