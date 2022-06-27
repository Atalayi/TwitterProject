using Project.Common.Dtos;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface ILikedTweetService
    {
        public Task<LikedTweet> AddLikedTweetAsync(LikedTweet entity);

        public Task<List<LikedTweetDto>> GetAllLikesAsync();

        public Task LikeTweetAsync(LikedTweetDto dto);

        public Task UnlikeTweetAsync(LikedTweetDto dto);
    }
}
