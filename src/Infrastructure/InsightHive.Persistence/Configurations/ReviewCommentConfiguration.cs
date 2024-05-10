using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Configurations
{
    internal class ReviewCommentConfiguration : IEntityTypeConfiguration<ReviewComment>
    {
        public void Configure(EntityTypeBuilder<ReviewComment> builder)
        {
            builder.HasKey(e => new { e.ReviewId, e.CommentId, e.ReviewerId });

            builder.HasOne(e => e.Review)
                .WithMany(e=>e.ReviewComments)
                .HasForeignKey(e=>e.ReviewId);

            builder.HasOne(e => e.Comment)
                .WithMany(e => e.ReviewComments)
                .HasForeignKey(e=>e.CommentId);

            builder.HasOne(e=>e.Reviewer)
                .WithMany(e => e.ReviewComments)
                .HasForeignKey(e=>e.ReviewerId);

        }
    }
}
