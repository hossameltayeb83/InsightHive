using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task<bool> AddReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddReviewCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> GetCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Comment>> GetCommentListAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<Review?> GetReviewByIdAsync(int reviewId, int maxComments)
        {
            throw new NotImplementedException();
        }

        public Task<Review?> GetReviewByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReviewCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
