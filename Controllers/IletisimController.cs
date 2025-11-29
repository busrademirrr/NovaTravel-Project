using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar; // Modellerin olduğu namespace

namespace TravelTripProject1.Controllers
{
    public class IletisimController : Controller
    {
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(iletisim p)
        {
            c.iletisims.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}