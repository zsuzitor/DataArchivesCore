using DataArchives.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class Article : IArchivesData
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Weight { get; set; }

        public bool Public { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Head { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Содержание")]
        public string Body { get; set; }

        public int Lvl { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<ImageDataArchives> Images { get; set; }

        //[NotMapped]
        //public int? SectionParrentId { get; set; }
        //[JsonProperty("Section_parrentId")]
        public int SectionParrentId { get; set; }
        public Section SectionParrent { get; set; }
        public Article()
        {
            Id = 0;
            Weight = 1000;
            Public = false;
            Head = "Default";
            Body = "";
            Lvl = 1;
            UserId = null;
            SectionParrentId = 0;

            Images = new List<ImageDataArchives>();
        }

        public Article(string head, string userId, int lvl, int sectionParrentId) : this()
        {
            Head = head;
            UserId = userId;
            SectionParrentId = sectionParrentId;
            Lvl = lvl;
        }


        public int GetTypeRecord() => 2;



        //проверяется доступ для просмотра
        public async static Task<Article> GetIfHaveAccess(ApplicationDbContext db, string userId, int? articleId)
        {
            if (articleId == null)
                return null;
            return await db.Articles.Where(x1 => x1.Id == articleId && (x1.UserId == userId || x1.Public)).FirstOrDefaultAsync();
        }
        //получение без проверок
        public async static Task<Article> Get(ApplicationDbContext db, int? articleId)
        {
            if (articleId == null)
                return null;
            return await db.Articles.Where(x1 => x1.Id == articleId).FirstOrDefaultAsync();
        }


        //есть проверки, редактирование в бд
        public async Task<bool> TryEditSimpleInDb(ApplicationDbContext db, string head, string userId)
        {
            if (this.UserId != null && this.UserId == userId && !string.IsNullOrWhiteSpace(head))
            {
                this.Head = head;

                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> TryDeleteSection(ApplicationDbContext db, string userId)
        {
            if (this.UserId != userId)
                return false;
            //возможно надо загружать изображения
            db.Articles.Remove(this);
            await db.SaveChangesAsync();
            return true;
        }

    }
}
