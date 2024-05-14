using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightHive.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Password)
              .HasMaxLength(100)
              .IsUnicode(false);
            builder.Property(e => e.Name)
               .HasMaxLength(100);
            builder.HasOne(e => e.Owner)
                .WithOne(e => e.User)
                .HasForeignKey<Owner>(e => e.UserId);

            builder.HasOne(e => e.Reviewer)
                .WithOne(e => e.User)
                .HasForeignKey<Reviewer>(e => e.UserId);
        }
    }
}
