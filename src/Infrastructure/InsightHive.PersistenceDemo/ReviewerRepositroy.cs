using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.PersistenceDemo
{
    internal class ReviewerRepositroy : BaseRepository<Reviewer>, IReviewerRepository
    {
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
