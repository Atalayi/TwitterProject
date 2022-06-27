using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class Tweet : ImageEntity
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<LikedTweet> LikedTweets { get; set; }
    }
}
