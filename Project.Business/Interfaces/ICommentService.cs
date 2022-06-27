using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(Comment entity);
    }
}
