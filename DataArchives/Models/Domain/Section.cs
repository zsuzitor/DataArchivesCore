using DataArchives.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class Section : IArchivesData
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

        public int Lvl { get; set; }

        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //[JsonProperty("Section_parrentId")]
        public int? SectionParrentId { get; set; }//для главной секции будет у всех пользователей null
        public Section SectionParrent { get; set; }

        public List<Section> Sections { get; set; }

        public List<Article> Articles { get; set; }

        public Section()
        {
            Id = 0;
            Lvl = 0;
            Weight = 1000;
            Public = false;
            Head = "Hello Word";
            UserId = null;
            SectionParrentId = null;

            Sections = new List<Section>();
            Articles = new List<Article>();

        }
        public Section(string userId) : this()
        {
            UserId = userId;
        }
        public Section(string head,string userId) : this(userId)
        {
            Head = head;
        }
        public Section(string head, string userId,int lvl,int? sectionParrentId) : this(head,userId)
        {
            Lvl = lvl;
            SectionParrentId = sectionParrentId;
        }

        //метод для определения типа, если мы работаем с общим интерфейсом для секций и статей
        public int GetTypeRecord() => 1;


         //this-новая секция которую надо добавить
        public async Task<Section> TryAddSectionToChilds(ApplicationDbContext db,string head,string userId,  int? sectionParrentId)
        {

            if (this.UserId == userId&&!string.IsNullOrWhiteSpace(head))
            {
                Section res = new Section(head, userId, this.Lvl + 1, sectionParrentId);
                db.Sections.Add(res);
                await db.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<Article> TryAddArticleToChilds(ApplicationDbContext db, string head, string userId)
        {
            if (this.UserId == userId && !string.IsNullOrWhiteSpace(head))
            {
                Article res = new Article(head, userId,this.Lvl+1, this.Id);
                db.Articles.Add(res);
                await db.SaveChangesAsync();
                return res;
            }
            return null;
        }

        //проверяется доступ для просмотра
        public async static Task<Section> GetIfHaveAccess(ApplicationDbContext db, string userId, int? sectionId)
        {
            if (sectionId == null)
                return null;
            return await db.Sections.Where(x1 => x1.Id == sectionId && (x1.UserId == userId || x1.Public)).FirstOrDefaultAsync();
        }
        //получение без проверок
        public async static Task<Section> Get(ApplicationDbContext db, int? sectionId)
        {
            if (sectionId == null)
                return null;
            return await db.Sections.Where(x1 => x1.Id == sectionId).FirstOrDefaultAsync();
        }

        //есть проверки, редактирование в бд
        public async Task<bool> TryEditInDb(ApplicationDbContext db, int weight, bool public_, string head, string userId)
        {
            if (this.UserId!=null&&this.UserId == userId && !string.IsNullOrWhiteSpace(head))
            {
                this.Weight = weight;
                this.Public = public_;
                this.Head = head;

                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async static Task<Section> AddMainSection(ApplicationDbContext db, string userId)
        {
            Section res = new Section(userId);
             db.Sections.Add(res);
            await db.SaveChangesAsync();
            return res;
        }
        public async Task<bool> TryDeleteSection(ApplicationDbContext db, string userId)
        {
            if (this.UserId != userId)
                return false;
            if (this.SectionParrentId != null)
            {
                //не главная секция
                await db.Entry(this).Collection(x1 => x1.Sections).LoadAsync();
                await db.Entry(this).Collection(x1 => x1.Articles).LoadAsync();
                db.Sections.Remove(this);
            }
            else
            {
                //главная секция
                var sectionForDel=await db.Entry(this).Collection(x1 => x1.Sections).Query().ToListAsync();
                var articleForDel = await db.Entry(this).Collection(x1 => x1.Articles).Query().ToListAsync();
                db.Sections.RemoveRange(sectionForDel);
                db.Articles.RemoveRange(articleForDel);
            }

            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoadChildsIfAccess(ApplicationDbContext db, string userId)
        {
            if (this.UserId != userId && !this.Public)
                return false;
            await db.Entry(this).Collection(x1 => x1.Sections).Query().Where(x1=>x1.Public||x1.UserId==userId).LoadAsync();
            await db.Entry(this).Collection(x1 => x1.Articles).Query().Where(x1 => x1.Public || x1.UserId == userId).LoadAsync();
            return true;
        }


        }


}
