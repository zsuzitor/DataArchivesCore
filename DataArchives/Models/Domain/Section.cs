using DataArchives.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models.Domain
{
    public class Section : IArchivesData
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

        public int Lvl { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //[JsonProperty("Section_parrentId")]
        public int? SectionParrentId { get; set; }//для главной секции будет у всех пользователей null
        public Section SectionParrent { get; set; }

        public List<Section> Sections { get; set; }

        public List<Article> Articles { get; set; }

        public Section()
        {
            Id = 0;
            Lvl = 0;
            Weight = 1000;
            Public = false;
            Head = "Hello Word";
            UserId = null;
            SectionParrentId = null;
        }
        public Section(string userId) : this()
        {
            UserId = userId;
        }
        //public Section(string userId) : this()
        //{
        //    UserId = userId;
        //}

        public int GetTypeRecord() => 1;


       



    }


}
