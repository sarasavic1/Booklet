using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(x => x.GenreName).IsUnique();
            builder.Property(x => x.GenreName).IsRequired();

            builder.HasMany(x => x.BookGenres).WithOne(y => y.Genre).HasForeignKey(y => y.GenreId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
