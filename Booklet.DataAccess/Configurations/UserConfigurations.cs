using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();

            builder.Property(x => x.Address).IsRequired();

            builder.HasMany(x => x.Wishlists).WithOne(y => y.User).HasForeignKey(y=>y.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Orders).WithOne(y => y.User).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Carts).WithOne(y => y.User).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UserUseCases).WithOne(y => y.User).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AuditLogs).WithOne(y => y.User).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
