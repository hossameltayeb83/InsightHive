using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IBadgeRepository : IRepository<Badge>
    {
        Task<Badge> GetByNameWithReviewersAsync(BadgeName badgeName);
        Task AddTopContributorsAsync(List<Reviewer> reviewers);
        Task AddWeeklyBadgeAsync(Reviewer reviewer, BadgeName badgeName);
        Task<IReadOnlyList<Reviewer>> GetMonthlyTopContributorsAsync();
        Task<IReadOnlyList<Reviewer>> GetReviewersOfWeeklyBadgeAsync(BadgeName badgeName);
    }
}
