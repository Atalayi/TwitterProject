using Project.Business.Interfaces;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concretes
{
    
    public class CommentService : ICommentService
    {

        public readonly ICommentRepository _repo;

        public CommentService(ICommentRepository repo)
        {
            _repo = repo;
        }

        public Task<Comment> AddCommentAsync(Comment entity)
        {
            return _repo.AddAsync(entity);
        }
    }
}
