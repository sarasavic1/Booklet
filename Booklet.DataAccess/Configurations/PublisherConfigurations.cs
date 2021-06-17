using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class PublisherConfigurations : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Books).WithOne(y => y.Publisher).HasForeignKey(y => y.PublisherId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
