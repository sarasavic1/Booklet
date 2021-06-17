using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.OrderStatus)
                .HasDefaultValue(OrderStatus.Recieved);

            builder.HasMany(x => x.OrderLines).WithOne(y => y.Order).HasForeignKey(y => y.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
