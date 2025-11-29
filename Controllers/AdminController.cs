using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();

        // ---------------------------------------------------------
        // 1. DASHBOARD (İSTATİSTİKLER)
        // ---------------------------------------------------------
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.BlogSayisi = c.Blogs.Count();
            ViewBag.MesajSayisi = c.iletisims.Count();
            ViewBag.TurSayisi = c.TurPaketleris.Count();
            ViewBag.RezervasyonSayisi = c.Rezervasyons.Count();

            // Tahmini Ciro Hesabı (Basit Simülasyon)
            ViewBag.Kasa = c.Rezervasyons.Count() * 5000;

            return View();
        }

        // ---------------------------------------------------------
        // 2. TUR PAKETLERİ YÖNETİMİ
        // ---------------------------------------------------------
        public ActionResult TurListesi()
        {
            var degerler = c.TurPaketleris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniTur()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniTur(TurPaketleri p)
        {
            c.TurPaketleris.Add(p);
            c.SaveChanges();
            return RedirectToAction("TurListesi");
        }

        public ActionResult TurSil(int id)
        {
            var b = c.TurPaketleris.Find(id);
            c.TurPaketleris.Remove(b);
            c.SaveChanges();
            return RedirectToAction("TurListesi");
        }
 

        // ---------------------------------------------------------
        // 4. BLOG YÖNETİMİ
        // ---------------------------------------------------------
        public ActionResult BlogListesi()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniBlog(Blog p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("BlogListesi");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("BlogListesi");
        }

        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir", b);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogGuncelle(Blog p)
        {
            var blog = c.Blogs.Find(p.ID);
            blog.Aciklama = p.Aciklama;
            blog.Baslik = p.Baslik;
            blog.BlogImage = p.BlogImage;
            blog.Tarih = p.Tarih;
            c.SaveChanges();
            return RedirectToAction("BlogListesi");
        }

        // ---------------------------------------------------------
        // 5. YORUM YÖNETİMİ
        // ---------------------------------------------------------
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        // ---------------------------------------------------------
        // 6. MESAJ & REZERVASYON YÖNETİMİ
        // ---------------------------------------------------------
        public ActionResult MesajListesi()
        {
            var mesajlar = c.iletisims.ToList();
            return View(mesajlar);
        }

        public ActionResult MesajSil(int id)
        {
            var m = c.iletisims.Find(id);
            c.iletisims.Remove(m);
            c.SaveChanges();
            return RedirectToAction("MesajListesi");
        }

        public ActionResult RezervasyonListesi()
        {
            var rezervasyonlar = c.Rezervasyons.OrderByDescending(x => x.ID).ToList();
            return View(rezervasyonlar);
        }

        public ActionResult RezervasyonIptal(int id)
        {
            var r = c.Rezervasyons.Find(id);
            r.Durum = "İptal Edildi";
            c.SaveChanges();
            return RedirectToAction("RezervasyonListesi");
        }

        public ActionResult RezervasyonOnayla(int id)
        {
            var r = c.Rezervasyons.Find(id);
            r.Durum = "Onaylandı";
            c.SaveChanges();
            return RedirectToAction("RezervasyonListesi");
        }
        // --- HAKKIMIZDA YÖNETİMİ ---

        public ActionResult Hakkimizda()
        {
            // Veritabanındaki ilk (ve tek) kaydı getir
            var deger = c.Hakkimizdas.FirstOrDefault();

            // Eğer hiç veri yoksa (ilk kez açılıyorsa) boş bir tane oluştur ki hata vermesin
            if (deger == null)
            {
                deger = new Hakkimizda();
                c.Hakkimizdas.Add(deger);
                c.SaveChanges();
            }

            return View(deger);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HakkimizdaGuncelle(Hakkimizda p)
        {
            var h = c.Hakkimizdas.Find(p.ID);
            h.FotoUrl = p.FotoUrl;
            h.Aciklama = p.Aciklama;
            h.Vizyon = p.Vizyon;  // Yeni
            h.Misyon = p.Misyon;  // Yeni
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
        public ActionResult YorumOnayla(int id)
        {
            var y = c.Yorumlars.Find(id);
            y.Durum = true; // Yorumu Görünür Yap (Aktif)
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}