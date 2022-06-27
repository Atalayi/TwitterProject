using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.DataAccess.BaseMappings
{
    public abstract class ImageEntityMapping<T> : BaseEntityMapping<T> where T : ImageEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ImagePath).IsRequired(false);
            builder.Ignore(x => x.ImageFile);
        }
    }
}
