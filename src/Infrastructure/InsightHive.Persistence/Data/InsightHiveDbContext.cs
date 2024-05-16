using Bogus;
using InsightHive.Domain.Common;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Data
{
    public class InsightHiveDbContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Owner> Owners { get; set; }
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
     
                
                FakeData.Init(5,25);
                //modelBuilder.Entity<Attachment>().HasData(FakeData.Attachments);
                modelBuilder.Entity<Badge>().HasData(FakeData.Badges);
                modelBuilder.Entity<Business>().HasData(FakeData.Businesses.Take(FakeData.Businesses.Count / 2)); 
                modelBuilder.Entity<Category>().HasData(FakeData.Categories.Take(FakeData.Categories.Count/2));
                modelBuilder.Entity<Comment>().HasData(FakeData.Comments.Take(FakeData.Comments.Count / 2));
                modelBuilder.Entity<Filter>().HasData(FakeData.Filters.Take(FakeData.Filters.Count / 2));
                modelBuilder.Entity<Option>().HasData(FakeData.Options.Take(FakeData.Options.Count / 2));
                modelBuilder.Entity<Owner>().HasData(FakeData.Owners.Take(FakeData.Owners.Count / 2));
                modelBuilder.Entity<Reaction>().HasData(FakeData.Reactions);
                modelBuilder.Entity<Review>().HasData(FakeData.Reviews.Take(FakeData.Reviews.Count / 2));
                modelBuilder.Entity<Reviewer>().HasData(FakeData.Reviewers.Take(FakeData.Reviewers.Count / 2));
                modelBuilder.Entity<Role>().HasData(FakeData.Roles);
                modelBuilder.Entity<SubCategory>().HasData(FakeData.SubCategories.Take(FakeData.SubCategories.Count / 2));
                modelBuilder.Entity<User>().HasData(FakeData.Users.Take(FakeData.Users.Count / 2));
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static class FakeData
        {
            public static List<Badge> Badges { get; set; } = new();
            public static List<Attachment> Attachments { get; } = new ();
            public static List<Business> Businesses { get; } = new ();
            public static List<Category> Categories { get; set; } = new();
            public static List<Comment> Comments { get; } = new();
            public static List<Filter> Filters { get; } = new();
            public static List<Option> Options { get; } = new();
            public static List<Owner> Owners { get; } = new();
            public static List<Reaction> Reactions { get; set; } = new();
            public static List<Review> Reviews { get; } = new();
            public static List<Reviewer> Reviewers { get; } = new();
            public static List<Role> Roles { get; set; } = new();
            public static List<SubCategory> SubCategories { get; } = new();
            public static List<User> Users { get; } = new();


            public static void Init(int count,int seed)
            {
                var faker = new Faker();   
                FakeData.Badges= new List<Badge> { 
                    new Badge { Id=1,Name=BadgeName.TopContributor,Image="Badges/1_img.png" },
                    new Badge { Id=2,Name=BadgeName.CommentsMaster,Image="Badges/2_img.png" },
                    new Badge { Id=3,Name=BadgeName.ReviewsEmperor,Image="Badges/3_img.png" },
                    new Badge { Id=4,Name=BadgeName.ReactionsLord,Image="Badges/4_img.png" }                   
                };
                FakeData.Reactions = new List<Reaction> {
                    new Reaction { Id=1,Name=(ReactionValue)1 },
                    new Reaction { Id=2,Name=(ReactionValue)2 },
                    new Reaction { Id=3,Name=(ReactionValue)3 },
                    new Reaction { Id=4,Name=(ReactionValue)4 }
                };

                FakeData.Roles = new List<Role> {
                    new Role { Id=1,Title=(RoleTitle)1 },
                    new Role { Id=2,Title=(RoleTitle)2 },
                    new Role { Id=3,Title=(RoleTitle)3 },
                    new Role { Id=4,Title=(RoleTitle)4 }
                };


                var attachmentFaker = new Faker<Attachment>()
                   .RuleFor(a => a.Image, f => f.Image.LoremPixelUrl("Business"));               

                var businessId = FakeData.Businesses.Count+1;
                var businessFaker = new Faker<Business>()
                   .UseSeed(seed)
                   .RuleFor(b => b.Logo, _ => $"Business\\{businessId}_img.png")
                   .RuleFor(b => b.Id, _=>businessId++)
                   .RuleFor(b => b.Name, f => f.Company.CompanyName())
                   .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                   .RuleFor(b => b.Attachments, (f, b) =>
                   {
                       attachmentFaker.RuleFor(a => a.BusinessId, _ => b.Id);
                       var attachments = attachmentFaker.GenerateBetween(2, 5);
                       FakeData.Attachments.AddRange(attachments);
                       return null;
                   });


                var optionId = FakeData.Options.Count + 1;
                var optionFaker = new Faker<Option>()
                   .UseSeed(seed)
                   .RuleFor(b => b.Id, _ => optionId++)
                   .RuleFor(b => b.Content, f => f.Random.Word());

                var filterId = FakeData.Filters.Count + 1;
                var filterFaker = new Faker<Filter>()
                   .UseSeed(seed)
                   .RuleFor(filter => filter.Id,_=> filterId++)
                   .RuleFor(filter => filter.Name, f => f.Commerce.Department())
                   .RuleFor(filter => filter.Options, (f, filter) =>
                   {
                       optionFaker.RuleFor(o => o.FilterId, _ => filter.Id);
                       var options = optionFaker.GenerateBetween(2, 5);
                       FakeData.Options.AddRange(options);
                       return null;
                   });
                var filters = filterFaker.Generate(count);
                FakeData.Filters.AddRange(filters);


                var subCategoryId = FakeData.SubCategories.Count + 1;
                var subCategoryFaker = new Faker<SubCategory>()
                   .UseSeed(seed)
                   .RuleFor(sc => sc.Id, _ => subCategoryId++)
                   .RuleFor(sc => sc.Name, f => f.Commerce.Categories(1)[0]);

                var categoryId = FakeData.Categories.Count + 1;
                var categoryFaker = new Faker<Category>()
                   .UseSeed(seed)
                   .RuleFor(c => c.Id, _ => categoryId++)
                   .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
                   .RuleFor(c => c.SubCategories, (f, c) =>
                   {
                       subCategoryFaker
                       .RuleFor(sc => sc.CategoryId, _ => c.Id);
                       var subCategories = subCategoryFaker.GenerateBetween(2, 5);
                       FakeData.SubCategories.AddRange(subCategories);
                       return null;
                   });
                   //.RuleFor(c => c.Filters, (f, c) =>
                   //{
                   //    if (System.Diagnostics.Debugger.IsAttached == false)
                   //        System.Diagnostics.Debugger.Launch();
                   //    var filters = f.PickRandom(FakeData.Filters, f.Random.Int(2,4)).ToList();
                   //    foreach (var filter in filters)
                   //    {
                   //        filter.Categories.Add(c);
                   //    }
                   //    return filters;
                   //});
                var categories = categoryFaker.Generate(4);
                FakeData.Categories.AddRange(categories);

                var commentId = FakeData.Comments.Count + 1;
                var commentFaker = new Faker<Comment>()
                   .UseSeed(seed)
                   .UseDateTimeReference(new DateTime(2024, 5, 14))
                   .RuleFor(r => r.CreatedDate, f => f.Date.Recent(30))
                   .RuleFor(c => c.Id,_=> commentId++)
                   .RuleFor(c => c.Content, f => f.Rant.Review());

                var reviewId = FakeData.Reviews.Count + 1;
                var reviewFaker = new Faker<Review>()
                   .UseSeed(seed)
                   .UseDateTimeReference(new DateTime(2024,5,14))
                   .RuleFor(r=>r.CreatedDate,f=>f.Date.Recent(30))
                   .RuleFor(r => r.Image, _ => $"Review\\{reviewId}_img.png")
                   .RuleFor(r => r.Id,_=> reviewId++)
                   .RuleFor(r => r.Content, f => f.Rant.Review())
                   .RuleFor(r => r.Rate, f => f.Random.Float(1, 5))
                   .RuleFor(r => r.BusinessId, f => f.PickRandom(FakeData.Businesses.Select(e => e.Id)));

                var reviewerId = FakeData.Reviewers.Count + 1;
                var reviewerFaker = new Faker<Reviewer>()
                   .UseSeed(seed)
                   .RuleFor(r => r.Image, _ => $"Review\\{reviewerId}_img.png")
                   .RuleFor(r => r.Id,_=> reviewerId++)
                   .RuleFor(r => r.Age, f => f.Random.Int(18, 99))
                   .RuleFor(r => r.Gender, f => f.PickRandom<Gender>())
                   .RuleFor(r => r.Reviews , (f, r) =>
                   {
                       reviewFaker.RuleFor(review => review.ReviewerId , _ => r.Id);
                       var reviews = reviewFaker.GenerateBetween(2, 5);
                       FakeData.Reviews.AddRange(reviews);
                       return null;
                   })
                   .RuleFor(r => r.Comments, (f, r) =>
                   {
                       commentFaker.RuleFor(c => c.ReviewerId, _ => r.Id);
                       var comments = commentFaker.GenerateBetween(2, 5);
                       for (int i = 0; i < comments.Count; i++)
                           comments[i].ReviewId = f.PickRandom(FakeData.Reviews.Select(e => e.Id));                     
                       FakeData.Comments.AddRange(comments);
                       return null;
                   });


                var ownerId = FakeData.Owners.Count + 1;
                var ownerFaker = new Faker<Owner>()
                   .UseSeed(seed)
                   .RuleFor(o => o.Id,_=> ownerId++)
                   .RuleFor(o => o.BusinessId, (f, o) =>
                   {
                       //if (System.Diagnostics.Debugger.IsAttached == false)
                       //    System.Diagnostics.Debugger.Launch();
                       //var business = businessFaker.Generate(1)[0];
                       //business.OwnerId = o.Id;
                       //var subCategory = f.PickRandom(FakeData.SubCategories);
                       //business.SubCategoryId = subCategory.Id;
                       //var options = subCategory.Category.Filters.Select(e => e.Options);
                       //foreach (var setOfOptions in options)
                       //{
                       //    for (int i = 0; i < f.Random.Int(1, setOfOptions.Count); i++)
                       //    {
                       //        var opt = f.PickRandom(setOfOptions);
                       //        if (business.Options.Contains(opt))
                       //            business.Options.Add(opt);
                       //    }
                       //}
                       //FakeData.Businesses.Add(business);
                       //return business.Id;
                       var business = businessFaker.Generate(1);
                       business[0].OwnerId = o.Id;
                       business[0].SubCategoryId = f.PickRandom(SubCategories.Select(e => e.Id));
                       FakeData.Businesses.Add(business[0]);
                       return business[0].Id;
                   });





                var userId = FakeData.Users.Count + 1;
                var userFaker = new Faker<User>()
                   .UseSeed(seed)
                   .RuleFor(u => u.Id, _ => userId++)
                   .RuleFor(u => u.Password, _ => "password")
                   .RuleFor(u => u.Name, f => f.Internet.UserName())
                   .RuleFor(u => u.RoleId, (f,u) => {

                       int roleId= f.Random.Int(1, 2);
                       if (roleId == 1)
                       {
                           ownerFaker.RuleFor(o => o.UserId , _ => u.Id);
                           var owner = ownerFaker.Generate(1);
                           u.Email = $"owner{owner[0].Id}@gmail.com";
                           FakeData.Owners.Add(owner[0]);
                       }
                       else
                       {
                           reviewerFaker.RuleFor(o => o.UserId, _ => u.Id);
                           var reviewer = reviewerFaker.Generate(1);
                           u.Email = $"reviewer{reviewer[0].Id}@gmail.com";
                           FakeData.Reviewers.Add(reviewer[0]);
                       }
                       return roleId;
                   });
                var users = userFaker.Generate(20);
                FakeData.Users.AddRange(users);
            }
        }
    }
}
