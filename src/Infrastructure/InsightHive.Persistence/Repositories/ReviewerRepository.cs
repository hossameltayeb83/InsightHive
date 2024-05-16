using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewerRepository : BaseRepository<Reviewer>, IReviewerRepository
    {
        public ReviewerRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task AddImagePathAsync(int id, string path)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reviewer>> CalculateTopContributorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetByIdWithReviewsAndBadgesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetByIdWithUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetByUserIdWithUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
