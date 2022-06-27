using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Dtos.TweetDtos
{
    public class CreateTweetDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
