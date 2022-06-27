using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Models;
using Project.Entity.Entities;
using Project.UI.Filters;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [SessionFilter(false)]
        public ViewResult Login()
        {
            return View();
        }

        [SessionFilter(false)]
        public ViewResult Register()
        {
            return View();
        }

        //Login
        [HttpPost]
        public async Task<JsonResult> SignUp(UserDto model)
        {
            var res = await _userService.AddUserAsync(model);

            return Json(new ResponseModel { Message = res.Message, StatusCode = res.StatusCode });
        }

        //Register
        [HttpPost]
        public async Task<JsonResult> SignIn(UserDto model)
        {
            var responseModel = await _userService.SignInUserAsync(model);

            if (responseModel.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContext.Session.SetString("UserId", responseModel.Id.ToString());
                HttpContext.Session.SetString("Username", responseModel.UserName);
            }

            return Json(new ResponseModel { Message = responseModel.Message, StatusCode = responseModel.StatusCode });
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
