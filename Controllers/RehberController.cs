using System;
using System.Linq;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class RehberController : Controller
    {
        Context c = new Context();

       /* public ActionResult Index()
        {
            var degerler = c.Rehbers.ToList();
            return View(degerler);
        }
        public ActionResult RehberDetay(int id)
        {
            var deger = c.Rehbers.Where(x => x.ID == id).ToList();
            return View(deger);
        }
        */
        [HttpGet]
        public PartialViewResult RezervasyonYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult RezervasyonYap(Rezervasyon p)
        {
            p.Durum = "Bekliyor"; // Varsayılan olarak beklemede
            c.Rezervasyons.Add(p);
            c.SaveChanges();
            return PartialView();
        }
    }
}