using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            Anasayfa model = new Anasayfa();

            // 1. En son eklenen 3 Blog yazısını al
            model.Deger1 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();

            // 2. En popüler (veya son eklenen) 3 Tur paketini al
            model.Deger2 = c.TurPaketleris.OrderByDescending(x => x.ID).Take(3).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        // --- YAPAY ZEKA KODLARI BURADA ---

        [HttpGet]
        public PartialViewResult YapayZeka()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult YapayZeka(string Kategori, string Butce, string Sure)
        {
            var turlar = c.TurPaketleris.ToList();
            var adayTurlar = new List<TurPaketleri>();

            // 1. KATEGORİ FİLTRESİ (Kelime Bazlı)
            foreach (var tur in turlar)
            {
                string metin = (tur.Baslik + tur.Detay + tur.Bolge).ToLower();
                string kat = Kategori.ToLower();

                if (kat == "doğa" && (metin.Contains("yayla") || metin.Contains("doğa") || metin.Contains("karadeniz") || metin.Contains("kamp"))) adayTurlar.Add(tur);
                else if (kat == "tarih" && (metin.Contains("tarih") || metin.Contains("müze") || metin.Contains("antik") || metin.Contains("kapadokya"))) adayTurlar.Add(tur);
                else if (kat == "yemek" && (metin.Contains("yemek") || metin.Contains("lezzet") || metin.Contains("gurme"))) adayTurlar.Add(tur);
                else if (kat == "eğlence" && (metin.Contains("eğlence") || metin.Contains("plaj") || metin.Contains("tekne"))) adayTurlar.Add(tur);
            }
            if (adayTurlar.Count == 0) adayTurlar = turlar; // Boşsa hepsini al

            // 2. SÜRE FİLTRESİ (Basit Mantık)
            // Tur açıklamasında "2 gün", "3 gün" vb. geçiyor mu diye bakabiliriz veya veritabanında "Sure" alanı varsa onu kullanabiliriz.
            // Bizim veritabanında "Sure" alanı var (Örn: "3 Gece 4 Gün").

            var sureAdaylari = new List<TurPaketleri>();
            foreach (var tur in adayTurlar)
            {
                // "Kısa" seçtiyse ve tur açıklamasında "2 gün" veya "3 gün" geçiyorsa...
                if (Sure == "Kisa" && (tur.Sure.Contains("2") || tur.Sure.Contains("3"))) sureAdaylari.Add(tur);
                else if (Sure == "Orta" && (tur.Sure.Contains("4") || tur.Sure.Contains("5") || tur.Sure.Contains("6") || tur.Sure.Contains("7"))) sureAdaylari.Add(tur);
                else if (Sure == "Uzun" && (tur.Sure.Contains("8") || tur.Sure.Contains("9") || tur.Sure.Contains("10"))) sureAdaylari.Add(tur);
            }

            // Eğer süreye uygun bulamazsa, önceki aday listesinden devam et (Çok daraltmayalım)
            if (sureAdaylari.Count > 0) adayTurlar = sureAdaylari;


            // 3. BÜTÇE FİLTRESİ (En son fiyat filtresi uygula)
            TurPaketleri enUygunTur = null;

            if (Butce == "Ekonomik")
                enUygunTur = adayTurlar.Where(x => x.Fiyat <= 5000).OrderBy(x => x.Fiyat).FirstOrDefault();
            else if (Butce == "Orta")
                enUygunTur = adayTurlar.Where(x => x.Fiyat > 5000 && x.Fiyat <= 15000).FirstOrDefault();
            else
                enUygunTur = adayTurlar.Where(x => x.Fiyat > 15000).OrderByDescending(x => x.Fiyat).FirstOrDefault();

            // 4. Sonuç Yoksa Rastgele
            if (enUygunTur == null && adayTurlar.Count > 0)
            {
                Random rnd = new Random();
                enUygunTur = adayTurlar[rnd.Next(0, adayTurlar.Count)];
            }

            return PartialView("YapayZekaSonuc", enUygunTur);
        }
        [HttpGet]
        public PartialViewResult AboneOl()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AboneOl(Abone p)
        {
            c.Abones.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index"); // Sayfayı yeniler
        }
    }
}