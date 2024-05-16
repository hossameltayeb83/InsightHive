using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewReactionRepository : BaseRepository<ReviewReaction>, IReviewReactionRepository

    {
        public ReviewReactionRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<bool> DeleteAsync(int reviewId, int reviewerId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReaction?> GetByIdAsync(int reviewId, int reactionId, int reviewerId)
        {
            throw new NotImplementedException();
        }
    }
}
