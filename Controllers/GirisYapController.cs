using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();

        // Giriş Yap Sayfası
        public ActionResult Login()
        {
            return View();
        }

        // Giriş İşlemi (POST)
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            // Kullanıcı adı ve şifreyi kontrol et
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);

            if (bilgiler != null)
            {
                // Giriş Başarılı: Yetki ver ve Admin paneline gönder
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Hatalı Giriş: Sayfada kal
                return View();
            }
        }

        // Çıkış Yap İşlemi
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // Oturumu tamamen öldür
            return RedirectToAction("Login", "GirisYap");
        }
    }
}