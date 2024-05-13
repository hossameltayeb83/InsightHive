using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewReactionRepository : IRepository<ReviewReaction>
    {

        public Task<ReviewReaction?> GetByIdAsync(int reviewId, int reactionId, int reviewerId);
        public Task<bool> DeleteAsync(int reviewId, int reviewerId);
    }
}
