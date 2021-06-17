using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class CartConfiguratuons : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasMany(x => x.CartLines).WithOne(y => y.Cart).HasForeignKey(y => y.CartId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
