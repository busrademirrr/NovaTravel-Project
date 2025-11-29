using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject1.Models.Siniflar;

namespace TravelTripProject1.Controllers
{
    public class TurController : Controller
    {
        Context c = new Context();

        // 1. TURLARI LİSTELEME
        public ActionResult Index()
        {
            var turlar = c.TurPaketleris.ToList();
            return View(turlar);
        }

        // 2. TUR DETAY SAYFASI
        public ActionResult TurDetay(int id)
        {
            var tur = c.TurPaketleris.Where(x => x.ID == id).ToList();
            return View(tur);
        }

        // 3. REZERVASYON FORMU (GÖRÜNÜM)
        [HttpGet]
        public PartialViewResult RezervasyonYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        // 4. REZERVASYON İŞLEMİ (POST)
        [HttpPost]
        public ActionResult RezervasyonYap(Rezervasyon p)
        {
            // Tarih kontrolü
            if (p.Tarih == DateTime.MinValue) p.Tarih = DateTime.Now;

            // Durumu ayarla
            p.Durum = "Ödeme Bekleniyor";

            // Veriyi geçici olarak Session'da sakla (Henüz kaydetmiyoruz)
            Session["GeciciRezervasyon"] = p;

            // Ödeme ekranına yönlendir
            return RedirectToAction("OdemeEkrani", "Tur");
        }

        // 5. ÖDEME EKRANI (HESAPLAMA YAPAN KISIM)
        [HttpGet]
        public ActionResult OdemeEkrani()
        {
            if (Session["GeciciRezervasyon"] == null)
            {
                return RedirectToAction("Index", "Default");
            }

            var rezervasyon = (Rezervasyon)Session["GeciciRezervasyon"];

            // 1. Kişi Sayısını bul
            int kisi = 0;
            int.TryParse(rezervasyon.KisiSayisi, out kisi);

            // 2. Tur ID'sini bul (Şu an RezervasyonYapilanYer içinde ID var, örn: "2")
            int turId = 0;
            int.TryParse(rezervasyon.RezervasyonYapilanYer, out turId);

            // 3. Veritabanından o ID'ye sahip turu bul
            var tur = c.TurPaketleris.Find(turId);

            decimal birimFiyat = 0;

            if (tur != null)
            {
                birimFiyat = tur.Fiyat;

                // DÜZELTME: Ekranda "2" yazmasın diye, ID'yi silip Turun Gerçek Adını yazıyoruz.
                // Böylece veritabanına da "Kapadokya Turu" diye kaydolacak.
                rezervasyon.RezervasyonYapilanYer = tur.Baslik;
            }

            // 4. Toplam Tutarı Hesapla
            ViewBag.OdenecekTutar = kisi * birimFiyat;

            return View(rezervasyon);
        }

        // 6. ÖDEME ALINDI (VERİTABANINA KAYIT)
        [HttpPost]
        public ActionResult OdemeAlindi()
        {
            // Geçici rezervasyonu al
            var rezervasyon = (Rezervasyon)Session["GeciciRezervasyon"];

            if (rezervasyon != null)
            {
                // Durumu onayla
                rezervasyon.Durum = "Onaylandı (Ödendi)";

                // GERÇEK KAYIT İŞLEMİ
                c.Rezervasyons.Add(rezervasyon);
                c.SaveChanges();

                // Oturumu temizle
                Session["GeciciRezervasyon"] = null;

                // Başarılı sayfasına git
                return RedirectToAction("OdemeBasarili");
            }

            return RedirectToAction("Index", "Default");
        }

        // 7. TEŞEKKÜR SAYFASI
        public ActionResult OdemeBasarili()
        {
            return View();
        }
    }
}