using Project.Business.Concretes;
using Project.Common.Dtos;
using Project.Common.Dtos.TweetDtos;
using Project.Common.Models;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface ITweetService
    {
        public Task<List<TweetDto>> GetAllTweetsAsync();
        public Task<ResponseModel> AddTweetAsync(CreateTweetDto entity);
        //public Task<UserDto> GetTweetById(int id);
        public Task<List<TweetDto>> GetTweetById(int id);
        public Task<List<TweetDto>> GetUsersTweetsAsync(int userId);

    }
}
