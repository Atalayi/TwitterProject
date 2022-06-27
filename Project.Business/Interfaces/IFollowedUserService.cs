using Project.Common.Dtos;
using Project.Common.Models;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface IFollowedUserService
    {
        Task<List<FollowDto>> GetAllFollowsAsync();
        Task<FollowResponseObj> FollowAsync(FollowDto dto);
    }
}
