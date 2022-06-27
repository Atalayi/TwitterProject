using Project.Business.Interfaces;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    public class FollowingUserService : IFollowingUserService
    {
        private readonly IFollowingUsersRepository _repo;

        public FollowingUserService(IFollowingUsersRepository repo)
        {
            _repo = repo;
        }

        public Task<FollowingUser> AddFollowingUserAsync(FollowingUser entity)
        {
            return _repo.AddAsync(entity);
        }
    }
}
