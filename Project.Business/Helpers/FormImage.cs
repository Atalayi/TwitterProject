using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Helpers
{
    public static class FormImage
    {
        public static async Task TwitterImg(Tweet tweet)
        {
            // have folder img in wwwroot?
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            // Remove old photo in wwwroot
            if (tweet.ImageFile != null && tweet.ImagePath != null && tweet.ImagePath != "blank-profile-picture.png")
            {
                var oldPath = Path.Combine("wwwroot/img/", tweet.ImagePath);
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            if (tweet.ImageFile == null && tweet.ImagePath == null) tweet.ImagePath = "blank-profile-picture.png";

            else if (tweet.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(tweet.ImageFile.FileName);
                string extension = Path.GetExtension(tweet.ImageFile.FileName);

                tweet.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmddss") + extension;

                string path = Path.Combine("wwwroot/img/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await tweet.ImageFile.CopyToAsync(fileStream);
                }
            }
        }
    }
}
