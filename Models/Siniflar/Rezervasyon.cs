using System;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProject1.Models.Siniflar
{
    public class Rezervasyon
    {
        [Key]
        public int ID { get; set; }

        public string AdSoyad { get; set; }

        public string Mail { get; set; }

        public string Telefon { get; set; }

        public string KisiSayisi { get; set; }

        public DateTime Tarih { get; set; }

        // Hangi tur/otel için rezervasyon yapılıyor?
        public string RezervasyonYapilanYer { get; set; }

        // Onay durumu (Admin panelinden "Onaylandı" veya "Bekliyor" yapılacak)
        public string Durum { get; set; }
    }
}