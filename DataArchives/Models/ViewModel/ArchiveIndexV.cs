using DataArchives.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class ArchiveIndexV
    {
        public string UserId { get; set; }
        public Section MySection { get; set; }


        //если буду реализовывать что то типо фукции "продолжить работу"
        public List<Section> ForeignSections { get; set; }
        public List<IArchivesData> SearchedData { get; set; }
        

        public ArchiveIndexV()
        {
            MySection = null;
            ForeignSections = new List<Section>();
            SearchedData = new List<IArchivesData>();
        }
    }
}
