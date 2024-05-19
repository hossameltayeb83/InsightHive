using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;

namespace InsightHive.PersistenceDemo.Repositories
{

    public class ReviewReactopnRepository : BaseRepository<ReviewReaction>, IReviewReactionRepository
    {
        public ReviewReactopnRepository()
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
