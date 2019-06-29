using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class ImageDataArchives: AImage
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
