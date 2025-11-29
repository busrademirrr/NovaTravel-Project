using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TravelTripProject1.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet <Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<iletisim> iletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<TurPaketleri> TurPaketleris { get; set; }
        public DbSet<Abone> Abones { get; set; }

    }
}