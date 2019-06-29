using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class Article:IArchivesData
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Weight { get; set; }

        public bool Public { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Head { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Содержание")]
        public string Body { get; set; }

        public int Lvl { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<ImageDataArchives> Images { get; set; }

        //[NotMapped]
        //public int? SectionParrentId { get; set; }
        //[JsonProperty("Section_parrentId")]
        public int SectionParrentId { get; set; }
        public Section SectionParrent { get; set; }
        public Article()
        {
            Id = 0;
            Weight = 1000;
            Public = false;
            Head = "Default";
            Body = "";
            Lvl = 1;
            UserId = null;
            SectionParrentId = 0;
        }

        public int GetTypeRecord() => 2;
    }
}
