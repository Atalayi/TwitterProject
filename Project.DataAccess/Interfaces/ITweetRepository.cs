using Project.Core.DataAccess.Abstracts;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Interfaces
{
    public interface ITweetRepository : IRepository<Tweet>
    {
    }
}
