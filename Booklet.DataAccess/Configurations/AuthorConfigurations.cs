using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Books).WithOne(y => y.Author).HasForeignKey(y => y.AuthorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
