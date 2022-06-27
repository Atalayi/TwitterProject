using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    public class UserMapping : ImageEntityMapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
        }
    }
}
