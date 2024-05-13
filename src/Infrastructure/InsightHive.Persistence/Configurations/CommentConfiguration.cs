using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightHive.Persistence.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Content)
               .HasMaxLength(200);
            builder.HasOne(e => e.Review)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ReviewId);

            builder.HasOne(e => e.Reviewer)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ReviewerId);
        }
    }
}
