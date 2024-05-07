using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public Task<IQueryable<Comment>> GetByReviewIdAsync(int reviewId);
        public Task<ICollection<Comment>> GetByReviewIdAsync(int reviewId, int maxSize);
    }
}
