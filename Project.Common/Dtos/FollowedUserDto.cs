
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Dtos
{
    public class FollowedUserDto 
    {
        public int UserId { get; set; }
        public int FollowedUserID { get; set; }
        //public virtual User FollowUser { get; set; }
    }
}
