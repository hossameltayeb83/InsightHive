using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightHive.Persistence.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(e => e.Content)
                .HasMaxLength(300);
            builder.Property(e => e.Rate)
                .IsRequired();
            builder.Property(e => e.Image)
                .HasMaxLength(50);

        }
    }
}
