using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Dtos.TweetDtos;
using Project.Common.Models;
using Project.UI.Filters;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{
    [SessionFilter(true)]
    public class HomeController : Controller
    {
        private readonly ITweetService _tweetService;
        private readonly IUserService _userService;
        private readonly ILikedTweetService _likedTweetService;

        public HomeController(ITweetService tweetService, IUserService userService, ILikedTweetService likedTweetService)
        {
            _tweetService = tweetService;
            _userService = userService;
            _likedTweetService = likedTweetService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<PartialViewResult> GetTweets()
        {
            var tweets = await _tweetService.GetAllTweetsAsync();
            var users = await _userService.UserListAsync();
            var likedTweets = await _likedTweetService.GetAllLikesAsync();

            return PartialView("PartialViews/_TweetListPartialView", Tuple.Create<List<TweetDto>, List<UserDto>, List<LikedTweetDto>>(tweets, users, likedTweets));
        }

        [HttpPost]
        public async Task<JsonResult> AddTweet(CreateTweetDto model)
        {
            model.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var res = await _tweetService.AddTweetAsync(model);

            return Json(new ResponseModel { Message = res.Message, StatusCode = res.StatusCode });

        }

        [HttpPost]
        public async Task LikeTweet(LikedTweetDto model)
        {
            await _likedTweetService.LikeTweetAsync(model);
        }

        //Another User Profile Page Tweets
        public async Task<PartialViewResult> GetUsersTweets(int Id)
        {
            var userDto = await _userService.GetUserByUserId(Id);
            var usersTweets = await _tweetService.GetUsersTweetsAsync(userDto.Id);
            var likedTweets = await _likedTweetService.GetAllLikesAsync();
            return PartialView("PartialViews/ProfilePartialView", Tuple.Create<List<TweetDto>, UserDto, List<LikedTweetDto>>(usersTweets, userDto, likedTweets));
        }

        [HttpPost]
        public async Task<PartialViewResult> Searchbar(string input)
        {
            var users = await _userService.UserListAsync();
            var searched = users.Where(x => x.Name.ToLower().Contains(input.ToLower()) || x.Surname.ToLower().Contains(input.ToLower()) || x.Username.ToLower().Contains(input.ToLower())).ToList();

            return PartialView("PartialViews/_SearchPartialView", searched);
        }
    }
}
