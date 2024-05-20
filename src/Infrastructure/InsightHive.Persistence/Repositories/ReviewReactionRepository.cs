using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewReactionRepository : BaseRepository<ReviewReaction>, IReviewReactionRepository

    {
        public ReviewReactionRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteAsync(int reviewId, int reviewerId)
        {
            var reviewReacion = await _context.ReviewsReaction
                .FirstOrDefaultAsync(e => e.ReviewId == reviewerId && e.ReviewerId == reviewerId);
            _context.ReviewsReaction.Remove(reviewReacion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReviewReaction?> GetByIdAsync(int reviewId, int reactionId, int reviewerId)
        {
            return await _context.ReviewsReaction
                .FirstOrDefaultAsync(e =>
                    e.ReviewerId == reviewerId &&
                    e.ReactionId == reactionId &&
                    e.ReviewId == reviewId
                );
        }
    }
}
