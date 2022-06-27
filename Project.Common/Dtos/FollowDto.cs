using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Dtos
{
    public class FollowDto
    {
        public int Id { get; set; }
        public int FollowingUserId { get; set; }
        public int UserId { get; set; }
    }
}
