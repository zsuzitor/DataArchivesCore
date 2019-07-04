using DataArchives.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class ImageDataArchives : AImage
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public ImageDataArchives()
        {

        }


        public static List<ImageDataArchives> GetFromUploadsCollection(IFormFileCollection uploadsImages, string currentUserId, int articleId)
        {
            List<ImageDataArchives> res = new List<ImageDataArchives>();
            if (uploadsImages == null)
                return res;
            foreach (var i in uploadsImages)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (BinaryReader binaryReader = new BinaryReader(i.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)i.Length);
                }
                res.Add(new ImageDataArchives() { Data = imageData, UserId = currentUserId, ArticleId = articleId });
            }
            return res;
        }


        public async static Task<List<int>> DeleteImages(ApplicationDbContext db, int[] imagesId, string currentUserId)
        {
            List<int> res = new List<int>();
            if (currentUserId == null || imagesId.Length == 0)
                return res;
            var list = await db.ImagesDataArchives.Where(x1 => imagesId.Contains(x1.Id) && x1.UserId == currentUserId).ToListAsync();
            db.ImagesDataArchives.RemoveRange(list);
            await db.SaveChangesAsync();
            res = list.Select(x1 => x1.Id).ToList();
            return res;
        }
    }
}
