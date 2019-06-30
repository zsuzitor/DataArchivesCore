using DataArchives.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateRegistration { get; set; }


        public List<Section> Sections { get; set; }
        public List<Article> Articles { get; set; }
        public List<ImageDataArchives> ImagesDataArchives { get; set; }

        public ApplicationUser()
        {

        }



        public static async Task<Section> GetMainSection(ApplicationDbContext db, string userId)
        {
            var user = await db.Users.FirstOrDefaultAsync(x1 => x1.Id == userId);
            return await db.Entry<ApplicationUser>(user).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null).FirstAsync();
        }
        public async Task<Section> GetMainSection(ApplicationDbContext db)
        {
            return await db.Entry<ApplicationUser>(this).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null).FirstAsync();
        }

        public static async Task<Section> GetMainSectionWithCheckAccess(ApplicationDbContext db, string currentUserId, string userId)
        {
            var user = await db.Users.FirstOrDefaultAsync(x1 => x1.Id == userId);
            if (currentUserId == userId)
                return await db.Entry<ApplicationUser>(user).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null).FirstAsync();
            else
                return await db.Entry<ApplicationUser>(user).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null && x1.Public).FirstOrDefaultAsync();

        }
        public async Task<Section> GetMainSectionWithCheckAccess(ApplicationDbContext db, string currentUserId)
        {
            if (currentUserId == this.Id)
                return await db.Entry<ApplicationUser>(this).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null).FirstAsync();
            else
                return await db.Entry<ApplicationUser>(this).Collection(x1 => x1.Sections).Query().Where(x1 => x1.SectionParrentId == null && x1.Public).FirstOrDefaultAsync();

        }
    }
}
