using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IReviewerBadgeRepository : IRepository<ReviewerBadge>
    {
        Task<IReadOnlyList<ReviewerBadge>> GetMonthlyTopContributorsAsync();
        Task<ReviewerBadge> GetReviewerOfWeeklyBadgeAsync(BadgeName badgeName);
    }
}
