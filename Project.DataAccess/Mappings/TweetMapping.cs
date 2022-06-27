using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    public class TweetMapping : ImageEntityMapping<Tweet> 
    {
        public override void Configure(EntityTypeBuilder<Tweet> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User).WithMany(x => x.Tweets).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
