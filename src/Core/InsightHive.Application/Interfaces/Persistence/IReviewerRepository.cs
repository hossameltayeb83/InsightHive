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
        Task<Reviewer> GetByIdWithReviewsAndBadgesAsync(int id);
        Task<Reviewer> GetByIdWithUserAsync(int id);
        Task<Reviewer> GetByUserIdWithUserAsync(int id);
        Task AddImagePathAsync(int id, string path);
        Task<List<Reviewer>> CalculateTopContributorsAsync();
    }
}
