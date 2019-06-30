using DataArchives.Data;
using DataArchives.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Search
{
    public static class SearchArchives
    {

        public async static Task<List<Section>> GetSection(string str, string email, int type,ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            ISearcherArhive src;
            var user = await userManager.FindByEmailAsync(email);
            switch (type)
            {
                case 1:
                    src = new SearchLike(str, user?.Id, db.Sections, null);
                    break;
                default://#TODO тут другой должет быть
                    src = new SearchLike(str, user?.Id, db.Sections, null);
                    break;
            }
                
            return await src.SearchSections();

        }

        public async static Task<List<Article>> GetArticle(string str, string email, int type, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            ISearcherArhive src;
            var user = await userManager.FindByEmailAsync(email);
            switch (type)
            {
                case 1:
                    src = new SearchLike(str, user?.Id, null, db.Articles);
                    break;
                default://#TODO тут другой должет быть
                    src = new SearchLike(str, user?.Id, null, db.Articles);
                    break;
            }

            return await src.SearchArticles();
        }
        public async static Task GetAll(string str, string email, int type, ApplicationDbContext db, UserManager<ApplicationUser> userManager, List<Section> resultSection, List<Article> resultArticle)
        {
            ISearcherArhive src;
            var user = await userManager.FindByEmailAsync(email);
            switch (type)
            {
                case 1:
                    src = new SearchLike(str, user?.Id, db.Sections, db.Articles);
                    break;
                default://#TODO тут другой должет быть
                    src = new SearchLike(str, user?.Id, db.Sections, db.Articles);
                    break;
            }
            await src.SearchAll(resultSection, resultArticle);
            return;
        }
    }
}
