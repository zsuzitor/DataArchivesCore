using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataArchives.Data;
using DataArchives.Models.Domain;
using DataArchives.Models.Search;
using DataArchives.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DataArchives.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArchivesController(ApplicationDbContext db, UserManager<ApplicationUser> usermanager)
        {
            _db = db;
            _userManager = usermanager;
        }

        public async Task<ActionResult> Index()
        {
            // this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArchiveIndexV res = new ArchiveIndexV
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };
            if (res.UserId != null)
            {
                res.MySection = await ApplicationUser.GetMainSection(_db, res.UserId);
            }
            return View(res);
        }


        // [Authorize]
        public async Task<ActionResult> OwnDatas()
        {
            //var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (id != null)
            //{
            //    await _db.Sections.AddAsync(new Section(id));
            //    await _db.SaveChangesAsync();

            //}
            //test method+view

            //System.Linq.IQueryable<DataArchives.Models.Domain.ApplicationUser> g = _db.Users;
            return View();
        }


        public async Task<ActionResult> Search(string str, string email, int type)
        {
            SearchArchivesV res = new SearchArchivesV();
            await SearchArchives.GetAll(str, email, type, _db, _userManager, res.Sections, res.Articles);
            return PartialView(res);
        }

        public async Task<ActionResult> ForeignDatas(string email)
        {
            Section res = null;
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return PartialView(res);
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (user?.Id == currentUserId)
                return PartialView(res);
            res = await user.GetMainSectionWithCheckAccess(_db, currentUserId);

            return PartialView(res);
        }


        public async Task<ActionResult> GetSectionChilds(int? idSection)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Section section = await Section.GetIfHaveAccess(_db, currentUserId, idSection);
            await section.LoadChildsIfAccess(_db, currentUserId);
            OneSectionV res = new OneSectionV() { Section = section, UserId = currentUserId };
            return PartialView(res);
        }

        public async Task<ActionResult> DeleteSection(int? idSection)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Section section = await Section.GetIfHaveAccess(_db, currentUserId, idSection);
            if (section == null)
                return Json(2);//ошибка
            bool res = await section.TryDeleteSection(_db, currentUserId);

            if (section.SectionParrentId == null && res)
                return Json(0);//очищена
            if (res)
                return Json(1);//удалена
            return Json(2);//ошибка
        }

        public async Task<ActionResult> DeleteArticle(int? idArticle)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Article article = await Article.GetIfHaveAccess(_db, currentUserId, idArticle);
            if (article == null)
                return Json(2);//ошибка
            bool res = await article.TryDeleteSection(_db, currentUserId);

            if (res)
                return Json(1);//удалена
            return Json(2);//ошибка
        }

        public async Task<ActionResult> CreateSection(int? idParentSection, string head)
        {

            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Section section = await Section.GetIfHaveAccess(_db, currentUserId, idParentSection);
            var newSection = await section?.TryAddSectionToChilds(_db, head, currentUserId, idParentSection);
            if (newSection == null)
                return StatusCode(400);
            OneSectionV res = new OneSectionV() { Section = newSection, UserId = currentUserId };
            return PartialView(res);
        }

        public async Task<ActionResult> ChangeSection(int? idSection, string head, int weight = 1000, bool public_ = false)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Section section = await Section.GetIfHaveAccess(_db, currentUserId, idSection);
            var res = await section.TryEditInDb(_db, weight, public_, head, currentUserId);
            return Json(res);
        }

        public async Task<ActionResult> ChangeArticle(int? idArticle, string head)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Article article = await Article.GetIfHaveAccess(_db, currentUserId, idArticle);
            var res = await article.TryEditSimpleInDb(_db, head, currentUserId);
            return Json(res);
        }

        public async Task<ActionResult> CreateArticle(int? idParentSection, string head)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Section section = await Section.GetIfHaveAccess(_db, currentUserId, idParentSection);
            var newArticle = await section.TryAddArticleToChilds(_db, head, currentUserId);
            OneArticleV res = new OneArticleV(newArticle, currentUserId);
            return PartialView(res);
        }

        public async Task<ActionResult> ArticleRecord(int? id)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Article article = await Article.GetIfHaveAccess(_db, currentUserId, id);
            if (article == null)
                return StatusCode(404);
            ArticleRecordV res = new ArticleRecordV() { Article = article, UserId = currentUserId };
            if (article.UserId == currentUserId)
                res.Editable = true;
            return PartialView(res);
        }

        [HttpPost]
        public async Task<ActionResult> EditArticleRecord(Article model, IFormFileCollection uploadsImages, int[] imgForDelete)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid)
                return Json(false);
            Article article = await Article.GetIfHaveAccess(_db, currentUserId, model.Id);
            if (article == null || article.UserId != currentUserId)
                return Json(false);
            _db.ImagesDataArchives.AddRange(ImageDataArchives.GetFromUploadsCollection(uploadsImages, currentUserId, article.Id));
            await _db.SaveChangesAsync();
            List<int> deleted = await ImageDataArchives.DeleteImages(_db, imgForDelete, currentUserId);


            return Json(true);
        }

    }
}