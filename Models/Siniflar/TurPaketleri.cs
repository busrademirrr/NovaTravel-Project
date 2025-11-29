using System;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProject1.Models.Siniflar
{
    public class TurPaketleri
    {
        [Key]
        public int ID { get; set; }

        public string Baslik { get; set; } // Örn: Büyük Karadeniz Turu

        public string Resim { get; set; } // Turun kapak fotoğrafı

        public string Sure { get; set; } // Örn: 3 Gece 4 Gün

        public decimal Fiyat { get; set; } // Örn: 7500.00 (Finansal işlemler için decimal kullandık)

        public string Bolge { get; set; } // Örn: Karadeniz, Ege, Kapadokya

        public string Detay { get; set; } // Tur programının uzun açıklaması
    }
}