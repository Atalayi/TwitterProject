using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    public class CommentMapping : ImageEntityMapping<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CommentText).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Tweet).WithMany(x => x.Comments).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
