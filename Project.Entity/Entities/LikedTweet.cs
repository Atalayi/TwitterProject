using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class LikedTweet : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}
