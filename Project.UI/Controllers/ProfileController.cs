using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Models;
using Project.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{

    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITweetService _tweetService;
        private readonly IFollowedUserService _followedUserService;
        private readonly ILikedTweetService _likedTweetService;

        public ProfileController(IUserService userService, ITweetService tweetService, IFollowedUserService followedUserService, ILikedTweetService likedTweetService)
        {
            _userService = userService;
            _tweetService = tweetService;
            _followedUserService = followedUserService;
            _likedTweetService = likedTweetService;
        }

        [SessionFilter(true)]
        [Route("/@{username}")]
        public async Task<IActionResult> Index(string username)
        {
            if (username == "")
                return RedirectToAction("Index", "Home");
            if (username == HttpContext.Session.GetString("UserName"))
                return RedirectToAction(nameof(MyProfile));

            var check = await _userService.GetUserByUserName(username);
            if (check != null)
            {
                var follows = await _followedUserService.GetAllFollowsAsync();

                return View(Tuple.Create<UserDto, List<FollowDto>>(check, follows));
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<PartialViewResult> GetMyTweets(int Id)
        {
            var userDto = await _userService.GetUserByUserId(Id);
            var tweetDto = await _tweetService.GetTweetById(Id);
            var likedtweets = await _likedTweetService.GetAllLikesAsync();

            return PartialView("PartialViews/ProfilePartialView", Tuple.Create<List<TweetDto>, UserDto, List<LikedTweetDto>>(tweetDto, userDto, likedtweets));
        }

        public async Task<IActionResult> MyProfile()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var userDto = await _userService.GetUserByUserId(userId);
            return View(userDto);
        }
        
        [HttpPost]
        public async Task<JsonResult> Follow(FollowDto dto)
        {
            dto.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var response = await _followedUserService.FollowAsync(dto);
            var followList = await _followedUserService.GetAllFollowsAsync();
            var count = followList.Where(x => x.FollowingUserId == dto.FollowingUserId).Count();
            return Json(new FollowResponseObj() { Message = response.Message, StatusCode = response.StatusCode, FCount = count, FCheck = response.FCheck });
        }
    }
}
