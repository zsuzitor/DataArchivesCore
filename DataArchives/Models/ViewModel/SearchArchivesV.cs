using DataArchives.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class SearchArchivesV
    {
        public List<Section> Sections { get; set; }
        public List<Article> Articles { get; set; }


        public SearchArchivesV()
        {
            Sections = new List<Section>();
            Articles = new List<Article>();
        }
    }
}
