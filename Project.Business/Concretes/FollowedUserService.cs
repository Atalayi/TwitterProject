using Project.Business.Interfaces;
using Project.Common.Dtos;
using Project.Common.Models;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    public class FollowedUserService : IFollowedUserService
    {
        private readonly IFollowedUserRepository _repo;

        public FollowedUserService(IFollowedUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<FollowDto>> GetAllFollowsAsync()
        {
            var follows = await _repo.GetAllAsync();
            var dtoList = new List<FollowDto>();
            foreach (var item in follows)
            {
                dtoList.Add(new FollowDto() { Id = item.Id, UserId = item.UserId, FollowingUserId = item.FollowedUserID });
            }
            return dtoList;
        }

        public async Task<FollowResponseObj> FollowAsync(FollowDto dto)
        {
            var response = new FollowResponseObj();
            var check = await _repo.FirstOrDefaultAsync(x => x.UserId == dto.UserId && x.FollowedUserID == dto.FollowingUserId);

            if (check is null)
            {
                var followedUser = new FollowedUser();
                followedUser.UserId = dto.UserId;
                followedUser.FollowedUserID = dto.FollowingUserId;

                await _repo.AddAsync(followedUser);

                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Message = "İşlem başarılı";
                response.FCheck = true;
            }
            else
            {
                await _repo.DeleteAsync(check);
                response.Message = "Silme işlemi başarılı";
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.FCheck = false;
            }
            return response;
        }
    }
}
