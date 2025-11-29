using System.ComponentModel.DataAnnotations;

namespace TravelTripProject1.Models.Siniflar
{
    public class Abone
    {
        [Key]
        public int ID { get; set; }
        public string Mail { get; set; }
    }
}