using System;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProject1.Models.Siniflar
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; }
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }

        // YENİ EKLENENLER
        public string Vizyon { get; set; }
        public string Misyon { get; set; }
    }
}