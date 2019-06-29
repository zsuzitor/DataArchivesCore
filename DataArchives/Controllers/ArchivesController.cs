using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataArchives.Data;
using DataArchives.Models.Domain;
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

        public ActionResult Index()
        {
           // this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ArchiveIndexV res = new ArchiveIndexV();
            res.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (res.UserId != null)
            {
                ApplicationUser.GetMainSection(_db,res.UserId);
            }
            return View(res);
        }


       // [Authorize]
        public ActionResult OwnDatas()
        {

            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        public ActionResult ForegnDatas()
        {
            return View();
        }

    }
}