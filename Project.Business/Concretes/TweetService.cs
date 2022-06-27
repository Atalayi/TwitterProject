using Project.Business.Helpers;
using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Dtos.TweetDtos;
using Project.Common.Models;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _repo;

        public TweetService(ITweetRepository repo)
        {
            _repo = repo;
        }

       
        public async Task<List<TweetDto>> GetAllTweetsAsync()
        {
            var allTweets = await _repo.GetAllAsync();
            var dtoList = new List<TweetDto>();

            foreach (var item in allTweets)
            {
                dtoList.Add(new TweetDto() { Id = item.Id, Content = item.Content, UserId = item.UserId, CreatedDate = item.CreatedDate, ImagePath = item.ImagePath });
            }

            return dtoList;
        }
        public async Task<List<TweetDto>> GetUsersTweetsAsync(int userId)
        {
            var allTweets = await _repo.GetAllAsync(x => x.UserId == userId);
            var dtoList = new List<TweetDto>();

            foreach (var item in allTweets)
            {
                dtoList.Add(new TweetDto() { Id = item.Id, Content = item.Content, UserId = item.UserId, CreatedDate = item.CreatedDate, ImagePath = item.ImagePath });
            }

            return dtoList;
        }

        public async Task<ResponseModel> AddTweetAsync(CreateTweetDto entity)
        {
            var returnModel = new ResponseModel();

            if (entity.Content != null)
            {
                Tweet tweet = new Tweet();

                tweet.Content = entity.Content;
                tweet.UserId = entity.UserId;
                tweet.ImageFile = entity.ImageFile;
                //tweet.ImagePath = null;

                if (tweet.ImageFile != null)
                    await FormImage.TwitterImg(tweet);

                await _repo.AddAsync(tweet);

                returnModel.Message = "İşlem Başarılı";
                returnModel.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                returnModel.Message = "Tweet boş bırakılamaz.";
                returnModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            return returnModel;
        }

        public async Task<List<TweetDto>> GetTweetById(int id)
        {
            var tweet = await _repo.GetAllAsync(x => x.UserId == id);
            var dtoTweetList = new List<TweetDto>();
            foreach (var item in tweet)
            {
                dtoTweetList.Add(new TweetDto()
                {
                    Id = item.Id,
                    Content = item.Content,
                    UserId = item.UserId,
                    CreatedDate = item.CreatedDate
                });
            }
            return dtoTweetList;
        }


    }
}
