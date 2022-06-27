using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface IFollowingUserService
    {
        Task<FollowingUser> AddFollowingUserAsync(FollowingUser entity);
    }
}
