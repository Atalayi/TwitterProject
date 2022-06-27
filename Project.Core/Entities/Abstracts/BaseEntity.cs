using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Entities.Abstracts
{
    public  abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
