using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
         BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            BlogYorum by = new BlogYorum();

            // 1. Tüm Blogları Çek (Sol Taraf İçin)
            by.Deger1 = c.Blogs.OrderByDescending(x => x.ID).ToList();

            // 2. Son 5 Yorumu Çek (Sağ Sidebar - Son Yorumlar İçin)
            by.Deger2 = c.Yorumlars.OrderByDescending(x => x.ID).Take(5).ToList();

            // 3. Son 5 Blogu Çek (Sağ Sidebar - Son Yazılar İçin)
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();

            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            var blog = c.Blogs.Find(id);
            BlogYorum by = new BlogYorum();

            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            // SADECE ONAYLI (Durum == true) YORUMLARI GETİR
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id && x.Durum == true).ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();

            // --- KESİN EŞLEŞTİRME MANTIĞI ---

            // 1. Blog Başlığını ve Açıklamasını küçük harfe çevirip hazırla
            string aranan = blog.Baslik.ToLower();
            string aciklama = blog.Aciklama.ToLower();

            // 2. Önce sadece EŞLEŞENLERİ ara
            // Turun Bölgesi (Örn: Kapadokya) blog başlığında geçiyor mu?
            var eslesenTurlar = c.TurPaketleris
                .Where(x => !string.IsNullOrEmpty(x.Bolge) &&
                           (aranan.Contains(x.Bolge.ToLower()) || aciklama.Contains(x.Bolge.ToLower())))
                .Take(3)
                .ToList();

            // 3. KARAR ANI:
            if (eslesenTurlar.Count > 0)
            {
                // Eşleşen bulduysan SADECE onları göster.
                by.Deger4 = eslesenTurlar;
            }
            else
            {
                // Hiçbir şey bulamadıysan boş kalmasın, son eklenen 3 turu göster (Rastgele öneri)
                by.Deger4 = c.TurPaketleris.OrderByDescending(x => x.ID).Take(3).ToList();
            }

            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
           
           ViewBag.deger= id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult YorumYap(Yorumlar y)
        {
            y.Durum = false; // Yorum admin onayına düşsün diye false yapıyoruz
            c.Yorumlars.Add(y);
            c.SaveChanges();

            // DÜZELTME BURADA:
            // İşlem bitince "PartialView" döndürme, "Redirect" ile sayfaya geri dön.
            // y.Blogid sayesinde hangi blogdaysak oraya geri döneriz.
            return RedirectToAction("BlogDetay", "Blog", new { id = y.Blogid });
        }


    }
}