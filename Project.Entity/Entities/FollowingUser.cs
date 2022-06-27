using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class FollowingUser : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FollowingUserId { get; set; }
        //public virtual User FollowUser { get; set; }
    }
}
