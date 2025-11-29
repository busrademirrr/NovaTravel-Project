using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject1.Models.Siniflar
{
    public class Rehber
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string Baslik { get; set; } // Örn: Kapadokya Mağara Otel

        public string Aciklama { get; set; } // Detaylı tanıtım yazısı

        public string GorunurGorsel { get; set; } // Listede görünecek resim URL'si

        // GOOGLE MAPS İÇİN KRİTİK ALAN
        public string HaritaKonum { get; set; } // Google Maps'ten alacağımız "iframe" kodu buraya gelecek.

        // FİNANSAL YÖN İÇİN KRİTİK ALANLAR
        public string TahminiMaliyet { get; set; } // Örn: "Gecelik 2000 TL - 3000 TL"

        public string Kategori { get; set; } // Otel, Restoran, Müze, Gece Kulübü

        public int Puan { get; set; } // 1 ile 10 arasında bir puan (Gelecekte yıldız sistemi için)
    }
}