using Project.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Entities
{
    public class User : ImageEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<Tweet> Tweets { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<FollowedUser> FollowedUsers { get; set; }
        public virtual List<FollowingUser> FollowingUsers { get; set; }
        public virtual List<LikedTweet> LikedTweets { get; set; }
    }
}
