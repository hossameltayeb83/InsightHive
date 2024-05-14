using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightHive.Persistence.Configurations
{
    internal class ReviewReactionConfiguration : IEntityTypeConfiguration<ReviewReaction>
    {
        public void Configure(EntityTypeBuilder<ReviewReaction> builder)
        {
            builder.HasKey(e => new { e.ReviewId, e.ReactionId, e.ReviewerId });

            builder.HasOne(e => e.Review)
                .WithMany(e => e.ReviewReactions)
                .HasForeignKey(e => e.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Reaction)
                .WithMany(e => e.ReviewReactions)
                .HasForeignKey(e => e.ReactionId);

            builder.HasOne(e => e.Reviewer)
                .WithMany(e => e.ReviewReactions)
                .HasForeignKey(e => e.ReviewerId);

        }
    }
}
