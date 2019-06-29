using System;
using System.Collections.Generic;
using System.Text;
using DataArchives.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataArchives.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Article> Articles { get; set; }
        public DbSet<ImageDataArchives> ImagesDataArchives { get; set; }
        public DbSet<Section> Sections { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();//создаст БД если ее нет
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API см по тегу fluent
            base.OnModelCreating(modelBuilder);
        }

    }
}
