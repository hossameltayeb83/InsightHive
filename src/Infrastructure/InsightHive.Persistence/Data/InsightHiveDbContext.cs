using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Data
{
    public class InsightHiveDbContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<ReviewComment> ReviewsComment { get; set; }
        public DbSet<ReviewReaction> ReviewsReaction { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public InsightHiveDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
