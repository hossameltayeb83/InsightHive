using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<Review?> GetReviewByIdAsync(int reviewId, int maxComments);
        // navigations needed : Comments, (ReviewReactions -> then Reaction)
        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments);
        // navigations needed : Comments, (ReviewReactions -> then Reaction)
        public Task<IQueryable<Comment>> GetCommentListAsync(int reviewId);
    }
}
