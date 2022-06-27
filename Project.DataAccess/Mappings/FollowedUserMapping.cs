using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    internal class FollowedUserMapping : BaseEntityMapping<FollowedUser>
    {
        public override void Configure(EntityTypeBuilder<FollowedUser> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User).WithMany(x => x.FollowedUsers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.FollowUser).WithMany(x => x.FollowedUsers).HasForeignKey(x => x.FollowedUserID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
