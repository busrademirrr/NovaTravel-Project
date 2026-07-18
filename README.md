# 🌍 NOVA TRAVEL | Yapay Zeka Destekli Turizm ve Rezervasyon Portalı

Nova Travel, kullanıcıların hayalindeki tatili bulmasını kolaylaştıran, kural tabanlı yapay zeka (Rule-Based AI) destekli modern bir **Turizm Acentesi ve Rezervasyon Otomasyonudur**. ASP.NET MVC 5 mimarisi kullanılarak uçtan uca (Full-Stack) geliştirilmiş olup, e-ticaret dinamiklerini ve akıllı içerik yönetimini tek bir platformda buluşturur.

<div align="center">
  <img src="https://github.com/user-attachments/assets/6a85ca0f-cc6a-4121-a1eb-1d21dfbef982" alt="Nova Travel Anasayfa" width="850">
</div>

<br />

## 🚀 Canlı Demo

Projeyi canlı sunucu üzerinde test etmek için aşağıdaki bağlantıya tıklayabilirsiniz:
👉 **[Nova Travel Canlı Demo](http://novatravel-project.somee.com/Default/Index)**

*(**Not:** Ücretsiz sunucu altyapısı kullanıldığı için sunucu uyku modunda olabilir. Sitenin ilk açılışı 20-30 saniye sürebilir, lütfen bekleyiniz.)*

---

## 🌟 Öne Çıkan Özellikler

### 🤖 1. NovaBot: Yapay Zeka Destekli Seyahat Asistanı
Sıradan, sıkıcı filtreleme sistemlerinin yerini alan sohbet tabanlı interaktif asistan:
* **Kişiselleştirilmiş Deneyim:** Kullanıcıya tatil tercihlerini (Doğa, Tarih, Eğlence vb.), bütçesini ve kalacağı süreyi sorar.
* **Akıllı Filtreleme:** Arka planda çalışan **Rule-Based AI (Kural Tabanlı Yapay Zeka)** algoritması, veritabanındaki yüzlerce tur paketini tarayarak optimum fiyat/performans rotasını kullanıcıya önerir.

### 💳 2. E-Ticaret ve Gelişmiş Rezervasyon Simülasyonu
Tam kapsamlı bir dijital satış süreci kurgulanmıştır:
* **Dinamik Fiyatlandırma:** Seçilen kişi sayısı ve turun o anki güncel fiyatına göre toplam sepet tutarı anlık olarak hesaplanır.
* **Güvenli Ödeme Ekranı:** Kullanıcılar kredi kartı bilgilerini girerek simüle edilmiş güvenli ödeme adımını tamamlar.
* **Sipariş Takibi:** Yapılan rezervasyonlar veritabanına işlenir ve Admin panelinde "Ödeme Bekliyor" veya "Onaylandı" statüleriyle anlık takip edilebilir.

<div align="center">
  <img src="https://github.com/user-attachments/assets/393fb8cb-eb15-4eb5-aa99-d9565d9c61ba" alt="Tur Detay ve Rezervasyon" width="850">
</div>

### 📊 3. Kapsamlı Yönetim Paneli (Admin Dashboard)
Tüm sistemin tek bir merkezden yönetildiği yetkilendirilmiş (Authorized) kontrol merkezi:
* **Görsel İstatistikler:** Toplam rezervasyon, aktif turlar, gelen mesajlar ve tahmini ciro gibi kritik veriler dashboard üzerinde anlık grafiksel kartlarla sunulur.
* **Tam Kapsamlı CRUD İşlemleri:** Turlar, blog yazıları, kullanıcı yorumları ve yapay zeka yönlendirme verileri panel üzerinden eklenebilir, silinebilir veya güncellenebilir.
* **Güvenli Moderasyon:** Kullanıcıların bloglara yaptığı yorumlar, yönetici onayından geçmeden sitede (frontend) yayınlanmaz.

<div align="center">
  <img src="https://github.com/user-attachments/assets/2d59dd73-e44e-427c-932e-40b0836d72d3" alt="Admin Dashboard" width="850">
</div>

### 🧩 4. Akıllı İçerik ve Entegrasyonlar
* **Akıllı Blog Eşleştirme:** Kullanıcı bir blog yazısı okurken, yazının içeriğine ve lokasyon bilgisine en uygun tur paketi sayfanın altında otomatik olarak önerilir.
* **Dinamik Harita (Google Maps):** Tur detaylarında ve iletişim sayfalarında dinamik lokasyon konumlandırması.
* **Çoklu Dil Desteği:** Yabancı turistler için Google Translate API entegrasyonu.
* **Modern UI/UX:** Bootstrap altyapısı ile her cihaza %100 uyumlu (Responsive) ve akıcı arayüz tasarımı.

<div align="center">
  <img src="https://github.com/user-attachments/assets/8c7c9518-c0ae-4ae4-b891-d1d51eb99329" alt="Akıllı Blog Eşleştirme" width="850">
</div>

---

## 🛠️ Kullanılan Teknolojiler ve Mimari

Bu proje, katmanlı mimari prensiplerine uygun olarak aşağıdaki modern web teknolojileri ile inşa edilmiştir:

| Katman | Teknolojiler |
| :--- | :--- |
| **Backend** | C#, ASP.NET MVC 5, LINQ |
| **Veritabanı** | MS SQL Server, Entity Framework (Code First) |
| **Frontend** | HTML5, CSS3, JavaScript, jQuery, Bootstrap |
| **Araçlar & DevOps** | Visual Studio 2022, SSMS, Git, Somee Hosting |

---

## 💻 Kurulum (Localhost)

Projeyi kendi bilgisayarınızda derleyip çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

**1. Repoyu bilgisayarınıza klonlayın:**
```bash
git clone [https://github.com/busrademirrr/NovaTravel-Project.git](https://github.com/busrademirrr/NovaTravel-Project.git)
