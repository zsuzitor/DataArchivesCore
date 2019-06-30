using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataArchives.Data;
using DataArchives.Models.Domain;
using DataArchives.Models.Search;
using DataArchives.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult OwnDatas()
        {
            //test method+view

            //System.Linq.IQueryable<DataArchives.Models.Domain.ApplicationUser> g = _db.Users;
            return View();
        }

        
        public async Task<ActionResult> Search(string str,string email,int type)
        {
            SearchArchivesV res = new SearchArchivesV();
            await SearchArchives.GetAll(str,email,type,_db,_userManager,res.Sections, res.Articles);
            return PartialView(res);
        }

        public async Task<ActionResult> ForeignDatas(string email)
        {
            Section res = null;
            var user = await _userManager.FindByEmailAsync(email);
            if(user==null)
                return PartialView(res);
            string curentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            if (user?.Id==curentUserId)
                return PartialView(res);
            res = await user.GetMainSectionWithCheckAccess(_db, curentUserId);

            return PartialView(res);
        }

    }
}