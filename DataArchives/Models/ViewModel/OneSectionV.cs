using DataArchives.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class OneSectionV
    {
        public Section Section { get; set; }
        public string UserId { get; set; }

        public OneSectionV()
        {
            UserId = null;
            Section = null;
        }
    }
}
