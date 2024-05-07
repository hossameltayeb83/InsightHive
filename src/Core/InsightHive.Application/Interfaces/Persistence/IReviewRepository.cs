using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<IQueryable<Review>> GetReviewsByBusinessIdAsync(int businessId, int maxComments);
        public Task<Review?> GetReviewByIdAsync(int id);
        public Task<bool> AddReviewAsync(Review review);
        public Task<bool> UpdateReviewAsync(Review review);
        //public Task<IQueryable<Comment>
    }
}
