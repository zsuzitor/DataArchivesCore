using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.ViewModel
{
    public class MainHeaderV
    {
        public string Selected { get; set; }

        public MainHeaderV(string selected)
        {
            Selected = selected;
        }
    }
}
