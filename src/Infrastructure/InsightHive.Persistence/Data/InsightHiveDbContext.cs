using Bogus;
using InsightHive.Domain.Common;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<ReviewReaction> ReviewsReaction { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public InsightHiveDbContext(DbContextOptions options) : base(options) { }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Attachment>().HasData(FakeData.Attachments);
            modelBuilder.Entity<Badge>().HasData(FakeData.Badges);
        }

        public static class FakeData
        {
            public static List<Badge> Badges = new();
            public static List<Attachment> Attachments = new();
            public static List<Business> Businesses = new();
            public static List<Category> Categories { get; set; } = new();
            public static List<Comment> Comments { get; set; } = new();
            public static List<Filter> Filters { get; set; } = new();
            public static List<Owner> Owner { get; set; } = new();
            public static List<Reaction> Reactions { get; set; } = new();
            public static List<Review> Reviews { get; set; } = new();
            public static List<Reviewer> Reviewers { get; set; } = new();
            public static List<ReviewReaction> ReviewsReaction { get; set; } = new();
            public static List<Role> Roles { get; set; } = new();
            public static List<SubCategory> SubCategories { get; set; } = new();
            public static List<User> Users { get; set; } = new();


            public static void Init(int count)
            {

                var attachmentFaker = new Faker<Attachment>()
                   .RuleFor(p => p.Image, f => f.Image.LoremPixelUrl("Business"));


                var badgeId = 1;
                var badgeFaker = new Faker<Badge>()
                   .RuleFor(b => b.Id, _ => badgeId++)
                   .RuleFor(b => b.Name, f => f.PickRandom<BadgeName>());
                //.RuleFor(b => b.Attachments, (f, b) =>
                //{
                //    attachmentFaker.RuleFor(p => p.BadgeId, _ => b.BadgeId);

                //    var attachments = attachmentFaker.GenerateBetween(3, 5);

                //    FakeData.Attachments.AddRange(attachments);

                //    return null; // Badge.Posts is a getter only. The return value has no impact.
                //});

                var badges = badgeFaker.Generate(count);

                FakeData.Badges.AddRange(badges);

                var businessId = 1;
                var businessFaker = new Faker<Business>()
                   .RuleFor(b => b.Id, _ => businessId++)
                   .RuleFor(b => b.Name, f => f.Company.CompanyName())
                   .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                   .RuleFor(b => b.Logo, f => f.Image.LoremPixelUrl("Business"));

                //.RuleFor(b => b.Attachments, (f, b) =>
                //{
                //    attachmentFaker.RuleFor(p => p.BadgeId, _ => b.BadgeId);

                //    var attachments = attachmentFaker.GenerateBetween(3, 5);

                //    FakeData.Attachments.AddRange(attachments);

                //    return null; // Badge.Posts is a getter only. The return value has no impact.
                //});

                var businesses = businessFaker.Generate(count);

                FakeData.Businesses.AddRange(businesses);


                var categoryId = 1;
                var categoryFaker = new Faker<Category>()
                   .RuleFor(b => b.Id, _ => categoryId++)
                   .RuleFor(b => b.Name, f => f.Commerce.Categories(1)[0]);


                //.RuleFor(b => b.Attachments, (f, b) =>
                //{
                //    attachmentFaker.RuleFor(p => p.BadgeId, _ => b.BadgeId);

                //    var attachments = attachmentFaker.GenerateBetween(3, 5);

                //    FakeData.Attachments.AddRange(attachments);

                //    return null; // Badge.Posts is a getter only. The return value has no impact.
                //});

                var categories = categoryFaker.Generate(count);

                FakeData.Categories.AddRange(categories);

                var commentId = 1;
                var commentFaker = new Faker<Comment>()
                   .RuleFor(b => b.Id, _ => commentId++)
                   .RuleFor(b => b.Content, f => f.Rant.Review());


                //.RuleFor(b => b.Attachments, (f, b) =>
                //{
                //    attachmentFaker.RuleFor(p => p.BadgeId, _ => b.BadgeId);

                //    var attachments = attachmentFaker.GenerateBetween(3, 5);

                //    FakeData.Attachments.AddRange(attachments);

                //    return null; // Badge.Posts is a getter only. The return value has no impact.
                //});

                var comments = commentFaker.Generate(count);

                FakeData.Comments.AddRange(comments);




            }
        }
    }
}
