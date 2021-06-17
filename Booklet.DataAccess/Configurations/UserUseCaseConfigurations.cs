using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.DataAccess.Configurations
{
    public class UserUseCaseConfigurations : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UseCaseId).IsRequired();
        }
    }
}
