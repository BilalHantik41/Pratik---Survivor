# Pratik – Survivor

![.NET](https://img.shields.io/badge/.NET-8.0-green?style=flat-square)
![C#](https://img.shields.io/badge/language-C%23-blue?style=flat-square)

## Projenin Amacı

**Pratik – Survivor**, C# (.NET 8) ile geliştirilmiş basit fakat öğretici bir *Survivor* oyunu/simülasyonudur. Proje;

* Nesne yönelimli programlama (OOP) kavramlarını,
* Temel algoritma geliştirmeyi,
* Konsol/masaüstü arayüz bileşenleri ile kullanıcı etkileşimini

öğrenmek ve pekiştirmek için hazırlanmıştır.

> **Not:** Kod tabanı tamamen eğitim amaçlıdır; ticari kullanıma yönelik değildir.

## Özellikler

* 👥 **Oyuncu Yönetimi** – Oyuncu oluşturma, güncelleme ve silme
* 🏝️ **Ada Ortamı** – Rastgele kaynak dağılımı ve hava durumu döngüsü
* ⚔️ **Karşılaşma Mekaniği** – Oyuncuların rastlantısal müsabakalarda elenmesi
* 💾 **JSON ile Kalıcı Kayıt** – Oyun durumu dış dosyaya kaydedilebilir / geri yüklenebilir
* 🔌 **Eklenti Mimarisi** – Yeni oyun kuralları veya mini‑oyunlar eklemek için *interface* tabanlı yapı

## Ekran Görüntüleri

> Henüz eklenmedi. `docs/screenshots` klasörüne `.png` dosyalarınızı ekleyin ve bu bölümü güncelleyin.

## Gereksinimler

| Araç                                              | Sürüm              |
| ------------------------------------------------- | ------------------ |
| [.NET SDK](https://dotnet.microsoft.com/download) | **8.0** veya üzeri |
| Visual Studio / VS Code                           | Önerilir           |

## Kurulum

```bash
# Depoyu klonlayın
git clone https://github.com/BilalHantik41/Pratik---Survivor.git
cd Pratik---Survivor

# NuGet bağımlılıklarını çekin
dotnet restore
```

## Çalıştırma

```bash
# Konsol uygulaması olarak
dotnet run --project "Pratik - Survivor/Pratik - Survivor.csproj"
```

> Visual Studio kullanıyorsanız `Pratik - Survivor.sln` dosyasını açıp **Start** tuşuna basmanız yeterli olacaktır.

## Testler

> Test projesi henüz oluşturulmadı. `xUnit` veya `NUnit` ile birim testleri eklemeye davetlisiniz.

## Katkıda Bulunma

1. Bir *Issue* açarak hatayı veya geliştirmeyi bildirin.
2. Bir *fork* oluşturun ve özelliğinizi `feature/my-feature` adında bir dalda geliştirin.
3. `git commit -m "Açıklayıcı mesaj"` → `git push origin feature/my-feature`
4. Bir **Pull Request** oluşturun.

## Yol Haritası

* [ ] Temel oyun döngüsünün tamamlanması
* [ ] GUI (WinForms/WPF) desteği
* [ ] Çok oyunculu (network) mod
* [ ] Unit test kapsamının %80’e çıkarılması

## Lisans

Bu proje **MIT Lisansı** ile lisanslanmıştır. Ayrıntılar için `LICENSE` dosyasına bakın.

## İletişim

Her türlü soru ve öneri için GitHub üzerinden *Issue* açabilir veya [@BilalHantik41](https://github.com/BilalHantik41) ile iletişime geçebilirsiniz.

---

> README dosyası **27 Temmuz 2025** tarihinde oluşturulmuştur. Lütfen gerektiğinde güncellemeyi unutmayın!
