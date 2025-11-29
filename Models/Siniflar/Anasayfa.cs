using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject1.Models.Siniflar
{
    public class Anasayfa
    {
        public IEnumerable<Blog> Deger1 { get; set; }        // Blogları taşıyacak
        public IEnumerable<TurPaketleri> Deger2 { get; set; } // Turları taşıyacak
    }
}