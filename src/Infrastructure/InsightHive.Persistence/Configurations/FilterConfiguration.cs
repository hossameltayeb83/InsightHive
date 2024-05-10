﻿using InsightHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Persistence.Configurations
{
    internal class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}