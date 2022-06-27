using Project.Business.Concretes;
using Project.Common.Dtos;
using Project.Common.Models;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseModel> AddUserAsync(UserDto entity);
        public Task<ResponseModel> SignInUserAsync(UserDto model);
        public Task<bool> ControlEmail(string email);
        public Task<List<UserDto>> UserListAsync();
        public Task<UserDto> GetUserByUserName(string username);
        public Task<UserDto> GetUserByUserId(int id);

    }
}
