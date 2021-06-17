using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class WishlistConfigurations : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.WishlistLines).WithOne(y => y.Wishlist).HasForeignKey(y=>y.WishlistId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
