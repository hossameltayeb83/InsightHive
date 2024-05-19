using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Repositories
{
    public class ReviewerRepository : BaseRepository<Reviewer>, IReviewerRepository
    {
        public ReviewerRepository(InsightHiveDbContext context) : base(context){ }
            
        public async Task AddImagePathAsync(int id, string path)
        {
            var reviewer = await GetByIdAsync(id);
            reviewer.Image = path;
            await _context.SaveChangesAsync();
        }

        public Task<List<Reviewer>> CalculateTopContributorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Reviewer>> GetAllReviewersWithUserAsync()
        {
            return await _context.Reviewers.Include(e => e.User).ToListAsync();
        }

        public async Task<Reviewer> GetByIdWithReviewsAndBadgesAsync(int id)
        {
            return await _context.Reviewers.Include(e => e.Reviews)
                .Include(e => e.Badges).FirstAsync(e => e.Id == id);
        }

        public async Task<Reviewer> GetByIdWithUserAsync(int id)
        {
            return await _context.Reviewers.Include(e => e.User).FirstAsync(e => e.Id == id);
        }

        public async Task<Reviewer> GetByUserIdWithUserAsync(int id)
        {
            return await _context.Reviewers.Include(e => e.User).FirstAsync(e => e.UserId == id);
        }
    }
}
