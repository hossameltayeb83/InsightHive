using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<Review?> GetReviewByIdAsync(int reviewId, int maxComments);
        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments);
        public Task<Review?> GetReviewByIdAsync(int id);
        public Task<ReviewComment?> GetCommentAsync(int commentId);
        public Task<IQueryable<ReviewComment>> GetCommentListAsync(int reviewId);
        public Task<bool> AddReviewAsync(Review review);
        public Task<bool> AddReviewCommentAsync(ReviewComment reviewComment);
        public Task<bool> UpdateReviewAsync(Review review);
        public Task<bool> UpdateReviewCommentAsync(ReviewComment reviewComment);
    }
}
