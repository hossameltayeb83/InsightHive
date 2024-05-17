using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightHive.Persistence.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {

            builder.Property(e => e.Image)
                .HasMaxLength(50);
            builder.Property(e => e.Name)
                .HasConversion<string>()
                .HasSentinel(BadgeName.NaN);
        }
    }
}
