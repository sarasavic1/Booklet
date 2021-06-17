using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class FormatConfigurations : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {
            builder.HasIndex(x => x.FormatName).IsUnique();
            builder.Property(x => x.FormatName).IsRequired();

            builder.HasMany(x => x.Books).WithOne(y => y.Format).HasForeignKey(y => y.FormatId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
