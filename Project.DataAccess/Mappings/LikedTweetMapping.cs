using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    public class LikedTweetMapping : BaseEntityMapping<LikedTweet>
    {
        public override void Configure(EntityTypeBuilder<LikedTweet> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User).WithMany(x => x.LikedTweets).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Tweet).WithMany(x => x.LikedTweets).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
