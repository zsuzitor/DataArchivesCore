using DataArchives.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class ApplicationUser:IdentityUser
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



        public static Section GetMainSection(ApplicationDbContext db, string userId)
        {
            var user=db.Users.FirstOrDefault(x1 => x1.Id == userId);
            return db.Entry<ApplicationUser>(user).Collection(x1 => x1.Sections).Query().Where(x1=>x1.SectionParrentId==null).First();
        }
    }
}
