using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class AuditLogConfigurations : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.Property(x => x.LogDate).IsRequired();
            builder.Property(x => x.UseCaseName).IsRequired();
        }
    }
}
