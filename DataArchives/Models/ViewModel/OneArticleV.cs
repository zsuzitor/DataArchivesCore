using DataArchives.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class OneArticleV
    {
        public Article Article { get; set; }
        public string UserId { get; set; }

        public OneArticleV()
        {
            UserId = null;
            Article = null;
        }
        public OneArticleV(Article article,string userId)
        {
            Article = article;
            UserId = userId;
        }

    }
}
