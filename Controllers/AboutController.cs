using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            // FirstOrDefault: Listeyi değil, bulduğu İLK satırı (tek bir nesneyi) getirir.
            var degerler = c.Hakkimizdas.FirstOrDefault();
            return View(degerler);
        }
    }
}