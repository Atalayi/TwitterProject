using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Core.Entities.Abstracts
{
    public abstract class ImageEntity : BaseEntity
    {
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
