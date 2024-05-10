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
    internal class ReviewerRepositroy : BaseResponse<Reviewer>, IReviewerRepository
    {
        public Task<bool> AddAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetByIdAsync(int id)
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

        public Task<IReadOnlyList<Reviewer>> GetMonthlyTopContributorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> GetReviewerOfWeeklyBadgeAsync(BadgeName badgeName)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Reviewer>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reviewer> SelectAllAsync(Expression<Func<Reviewer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Reviewer>> SelectOneAsync(Expression<Func<Reviewer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Reviewer entity)
        {
            throw new NotImplementedException();
        }
    }
}
