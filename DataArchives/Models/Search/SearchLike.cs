using DataArchives.Data;
using DataArchives.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Search
{
    public class SearchLike:ISearcherArhive
    {
        public string Str { get; set; }
        public string UserId { get; set; }
        //public ApplicationDbContext _db { get; set; }
        public System.Linq.IQueryable<DataArchives.Models.Domain.Section> Sections { get; set; }
        public System.Linq.IQueryable<DataArchives.Models.Domain.Article> Articles { get; set; }

        //null-нет доступа, произошла ошибка
        public async Task<List<Section>> SearchSections()
        {
            if (Sections == null|| string.IsNullOrWhiteSpace(Str))
                return null;
            return await GetTaskSearchSections();
        }
        public async Task<List<Article>> SearchArticles()
        {
            if (Articles == null || string.IsNullOrWhiteSpace(Str))
                return null;
            return await GetTaskSearchArticles();
        }

        public async Task SearchAll(List<Section> resultSection, List<Article> resultArticles)
        {
            if (Articles == null|| Sections == null || string.IsNullOrWhiteSpace(Str))
                return;
            
            resultSection.AddRange(await GetTaskSearchSections());
            resultArticles.AddRange(await GetTaskSearchArticles());
        }

        public SearchLike(string str,string userId, IQueryable<Section> sections, IQueryable<Article> articles)
        {
            Str = str;
            UserId = userId;
            Sections = sections;
            Articles = articles;
        }


        private Task<List<Section>> GetTaskSearchSections()
        {
            return Sections.Where(x1 => (x1.UserId == UserId || x1.Public) &&
            EF.Functions.Like(x1.Head, $"%{Str}%")).OrderBy(x1 => x1.Weight).ToListAsync();
        }

        private Task<List<Article>> GetTaskSearchArticles()
        {
            return Articles.Where(x1 => (x1.UserId == UserId || x1.Public) &&
           (EF.Functions.Like(x1.Head, $"%{Str}%") || EF.Functions.Like(x1.Body, $"%{Str}%"))).OrderBy(x1 => x1.Weight).ToListAsync();
        }
    }
}
