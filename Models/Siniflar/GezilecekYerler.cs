using System;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProject1.Models.Siniflar
{
    public class GezilecekYerler
    {
        [Key]
        public int ID { get; set; }

        public string Baslik { get; set; } // Örn: Sümela Manastırı

        public string Aciklama { get; set; } // Kısa bilgi

        public string Resim { get; set; }

        // YAPAY ZEKA İÇİN EN ÖNEMLİ ALAN:
        public string Kategori { get; set; } // Buraya şunları yazacağız: "Tarih", "Doğa", "Yemek", "Eğlence"

        public string Sehir { get; set; } // Örn: Trabzon
    }
}