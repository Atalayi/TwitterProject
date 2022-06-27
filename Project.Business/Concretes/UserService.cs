using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Models;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ResponseModel> AddUserAsync(UserDto entity)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            bool emailVal = validateEmailRegex.IsMatch(entity.Email);
            Regex validatePasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            bool passwordVal = validatePasswordRegex.IsMatch(entity.Password);

            var returnModel = new ResponseModel();
            var msgBuilder = new StringBuilder();

            var emailState = await ControlEmail(entity.Email);
            var state = true;

            #region Validations

            if (emailState)
            {
                msgBuilder.AppendLine("<li>Email sistemde mevcut.</li>");
                returnModel.StatusCode = HttpStatusCode.BadRequest;
                state = false;
            }
            if (entity.ConfirmPassword != entity.Password)
            {
                msgBuilder.AppendLine("<li>Girdiğiniz şifreler uyumsuz</li>");
                returnModel.StatusCode = HttpStatusCode.BadRequest;
                state = false;
            }
            if (!emailVal)
            {
                state = false;
                msgBuilder.AppendLine("<li>Email formatı yanlış</li>");
                returnModel.StatusCode = HttpStatusCode.BadRequest;
            }
            if (!passwordVal)
            {
                state = false;
                msgBuilder.AppendLine("<li>Şifre formatı yanlış</li>");
                returnModel.StatusCode = HttpStatusCode.BadRequest;
            }
            #endregion

            if (state)
            {
                User user = new User();
                user.Email = entity.Email;
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Username = entity.Username;
                user.Gender = entity.Gender;
                user.Password = entity.Password;
                user.BirthDate = entity.BirthDate;
                user.ImagePath = null;

                await _repo.AddAsync(user);

                returnModel.Message = "İşlem Başarılı";
                returnModel.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                msgBuilder.Insert(0, "<ul>");
                msgBuilder.Insert(msgBuilder.Length - 1, "</ul>");
                returnModel.Message = msgBuilder.ToString();
            }

            return returnModel;
        }
        public async Task<bool> ControlEmail(string email)
        {
            var state = await _repo.AnyAsync(x => x.Email == email);

            return state;
        }

        public async Task<ResponseModel> SignInUserAsync(UserDto model)
        {
            var user = await _repo.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null || user.Password != model.Password)
            {
                return new ResponseModel() { Message = "Kullanıcı adı veya şifre hatalı", StatusCode = HttpStatusCode.BadRequest };
            }
            return new ResponseModel() { Message = "Giriş başarılı", StatusCode = HttpStatusCode.OK, UserName = user.Username, Id = user.Id };
        }

        public async Task<List<UserDto>> UserListAsync()
        {
            var allTweets = await _repo.GetAllAsync();
            var dtoList = new List<UserDto>();

            foreach (var item in allTweets)
            {
                dtoList.Add(new UserDto() { Id = item.Id, Surname = item.Surname, Name = item.Name, Username = item.Username });
            }

            return dtoList;
        }

        public async Task<UserDto> GetUserByUserId(int id)
        {
            var user = await _repo.FirstOrDefaultAsync(x => x.Id == id);
            var userDto = new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Gender = user.Gender,
                Password = user.Password,
                BirthDate = user.BirthDate,
                ImagePath = user.ImagePath
            };

            return userDto;
        }

        public async Task<UserDto> GetUserByUserName(string username)
        {
            var user = await _repo.FirstOrDefaultAsync(x => x.Username == username);
            var userdto = new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Gender = user.Gender,
                Password = user.Password,
                BirthDate = user.BirthDate,
                ImagePath = user.ImagePath

            };
            return userdto;
        }

    }
}
