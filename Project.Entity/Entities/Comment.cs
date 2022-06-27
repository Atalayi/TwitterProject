using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class Comment : ImageEntity
    {
        public string CommentText { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}
