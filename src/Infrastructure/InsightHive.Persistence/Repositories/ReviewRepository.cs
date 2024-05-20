using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<IQueryable<Comment>> GetCommentListAsync(int reviewId)
        {
            return Task.FromResult(
                _context.Reviews
                .Where(e => e.Id == reviewId)
                .SelectMany(e => e.Comments)
                );
        }

        public async Task<Review?> GetReviewByIdAsync(int reviewId, int maxComments)
        {
            return await _context.Reviews
                .Where(e => e.Id == reviewId)
                .Select(e => new Review
                {
                    Id = e.Id,
                    Content = e.Content,
                    Rate = e.Rate,
                    Image = e.Image,
                    BusinessId = e.BusinessId,
                    ReviewerId = e.ReviewerId,
                    Comments = e.Comments.Take(maxComments).ToList()
                })
                .FirstOrDefaultAsync();

        }

        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments)
        {
            var review = _context.Reviews
                .Where(e => e.BusinessId == businessId)
                .Select(e => new Review
                {
                    Id = e.Id,
                    Content = e.Content,
                    Rate = e.Rate,
                    Image = e.Image,
                    BusinessId = e.BusinessId,
                    ReviewerId = e.ReviewerId,
                    Comments = e.Comments.Take(maxComments).ToList()
                });
            return Task.FromResult(review);
        }
    }
}
