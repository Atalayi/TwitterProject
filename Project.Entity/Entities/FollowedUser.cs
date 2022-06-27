using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class FollowedUser : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FollowedUserID { get; set; }
        //public virtual User FollowUser { get; set; }
    }
}
