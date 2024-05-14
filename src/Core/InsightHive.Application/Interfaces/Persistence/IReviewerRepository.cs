using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewerRepository : IRepository<Reviewer>
    {
        Task<Reviewer> GetByIdWithReviewsAndBadgesAsync(int id);
        Task<Reviewer> GetByIdWithUserAsync(int id);
        Task<Reviewer> GetByUserIdWithUserAsync(int id);
        Task AddImagePathAsync(int id, string path);
        Task<List<Reviewer>> CalculateTopContributorsAsync();
    }
}
