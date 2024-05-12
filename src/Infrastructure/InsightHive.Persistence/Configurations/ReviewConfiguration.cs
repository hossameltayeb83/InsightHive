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
