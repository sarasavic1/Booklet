using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);

            builder.HasIndex(x => x.ISBN).IsUnique();
            builder.Property(x => x.ISBN).IsRequired();

            builder.Property(x => x.PublishDate).IsRequired();

            builder.Property(x => x.PageNumber).IsRequired();

            builder.HasMany(x => x.BookGenres).WithOne(y => y.Book).HasForeignKey(y => y.BookId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderLines).WithOne(y => y.Book).HasForeignKey(y => y.BookId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.WishlistLines).WithOne(y => y.Book).HasForeignKey(y => y.BookId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.CartLines).WithOne(y => y.Book).HasForeignKey(y => y.BookId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
