using DataArchives.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class ArticleRecordV
    {
        public Article Article { get; set; }
        public string UserId { get; set; }
        public bool Editable { get; set; }

        public ArticleRecordV()
        {
            Editable = false;

        }
    }
}
