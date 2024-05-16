using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using InsightHive.Persistence.Data;

namespace InsightHive.Persistence.Repositories
{
    public class BadgeRepository : BaseRepository<Badge>, IBadgeRepository
    {
        public BadgeRepository(InsightHiveDbContext context) : base(context)
        {
        }

        public Task AddTopContributorsAsync(List<Reviewer> reviewers)
        {
            throw new NotImplementedException();
        }

        public Task AddWeeklyBadgeAsync(Reviewer reviewer, BadgeName badgeName)
        {
            throw new NotImplementedException();
        }

        public Task<Badge> GetByNameWithReviewersAsync(BadgeName badgeName)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Reviewer>> GetMonthlyTopContributorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Reviewer>> GetReviewersOfWeeklyBadgeAsync(BadgeName badgeName)
        {
            throw new NotImplementedException();
        }
    }
}
