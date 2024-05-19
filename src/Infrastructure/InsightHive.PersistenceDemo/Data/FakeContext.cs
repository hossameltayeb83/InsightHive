using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.PersistenceDemo.Data
{
    public class FakeContext : DbContext
    {
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
