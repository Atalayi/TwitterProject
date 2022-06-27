using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    public class LikedTweetService : ILikedTweetService
    {
        private readonly ILikedTweetRepository _repo;

        public LikedTweetService(ILikedTweetRepository repo)
        {
            _repo = repo;
        }

        public Task<LikedTweet> AddLikedTweetAsync(LikedTweet entity)
        {
            return _repo.AddAsync(entity);
        }

        public async Task<List<LikedTweetDto>> GetAllLikesAsync()
        {
            var likeds = await _repo.GetAllAsync();
            var dtoList = new List<LikedTweetDto>();

            foreach (var item in likeds)
            {
                dtoList.Add(new LikedTweetDto { UserId = item.UserId, TweetId = item.TweetId });
            }

            return dtoList;
        }

        public async Task LikeTweetAsync(LikedTweetDto dto)
        {
            var check = await _repo.FirstOrDefaultAsync(x => x.TweetId == dto.TweetId && x.UserId == dto.UserId);

            if (check == null)
            {
                var liked = new LikedTweet()
                {
                    UserId = dto.UserId,
                    TweetId = dto.TweetId
                };
                await _repo.AddAsync(liked);
            }
            else
            {
                await _repo.DeleteAsync(check);
            }
        }

        public async Task UnlikeTweetAsync(LikedTweetDto dto)
        {
            await _repo.AnyAsync();
        }
    }
}
