using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelTripProject1.Controllers
{
    public class ErrorController : Controller
    {
        // 404 - Sayfa Bulunamadı
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true; // IIS'in standart hata sayfasını ezmek için
            return View();
        }

        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}