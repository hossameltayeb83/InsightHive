
namespace InsightHive.Application.Interfaces.Infrastructure
{
    public interface IBackgroundService
    {
        Task SetWeeKlyBadges();
        Task SetMonthlyTopContributors();
    }
}
