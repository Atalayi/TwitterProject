using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.DataAccess.BaseMappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Mappings
{
    public class FollowingUserMapping : BaseEntityMapping<FollowingUser>
    {
        public override void Configure(EntityTypeBuilder<FollowingUser> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User).WithMany(x => x.FollowingUsers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.FollowUser).WithMany(x => x.FollowingUsers).HasForeignKey(x => x.FollowingUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
