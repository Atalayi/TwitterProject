
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Dtos
{
    public class FollowingUserDto 
    {
        public int UserId { get; set; }
        public int FollowingUserId { get; set; }
        //public virtual User FollowUser { get; set; }
    }
}
