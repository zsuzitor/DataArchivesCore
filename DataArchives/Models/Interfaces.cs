﻿using DataArchives.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataArchives.Models
{
    public class Interfaces
    {
    }


    public interface IArchivesData
    {
        int Id { get; set; }
        int Weight { get; set; }
        bool Public { get; set; }
        string Head { get; set; }
        int Lvl { get; set; }
        string UserId { get; set; }
        //int? SectionParrentId { get; set; }

            //1-секция, 2-статья
        int GetTypeRecord();
    }


    public abstract class AImage
    {
        //int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] Data { get; set; }

        public string UserId { get; set; }//тот кто загрузил??
        public ApplicationUser User { get; set; }

        public AImage()
        {
            Id = 0;
            Data = null;
            Birthday = DateTime.Now;
            UserId = null;
            User = null;
        }
    }

}
