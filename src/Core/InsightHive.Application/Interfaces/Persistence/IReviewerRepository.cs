using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewerRepository : IRepository<Reviewer>
    {
        Task<Reviewer> GetByIdWithUserAsync(int id);
        Task<Reviewer> GetByUserIdWithUserAsync(int id);
        Task<IReadOnlyList<Reviewer>> GetMonthlyTopContributorsAsync();
        Task<Reviewer> GetReviewerOfWeeklyBadgeAsync(BadgeName badgeName);
    }
}
