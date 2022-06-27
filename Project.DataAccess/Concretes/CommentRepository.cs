using Project.Core.DataAccess.Concretes;
using Project.DataAccess.Context;
using Project.DataAccess.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Concretes
{
    public class CommentRepository : GenericRepository<Comment, AppDbContext>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
