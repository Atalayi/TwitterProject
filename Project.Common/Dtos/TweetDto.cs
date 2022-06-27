using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Dtos
{
    public class TweetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        //public virtual List<Comment> Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; }
    }
}
