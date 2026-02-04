# WPF-Tetris-Game (Avalonia Refactor)

Cool Tetris oyunu, eski bir WPF sürümünün **Avalonia UI** kullanılarak modernize edilmiş ve refactor edilmiş halidir. Bu proje, klasik Tetris mekaniklerini modern bir masaüstü uygulama framework'ü ile birleştirir.

## 🚀 Proje Hakkında
Bu proje, eski bir WPF (Windows Presentation Foundation) Tetris uygulamasının, platformlar arası (Cross-platform) destek sunan **Avalonia UI** ve **.NET 9** kullanılarak tamamen yeniden yazılmış ve optimize edilmiş versiyonudur.

### Temel Özellikler
- **Ghost Piece:** Bloğun nereye düşeceğini gösteren gölge sistem.
- **Hold System:** İhtiyacınız olan bloğu daha sonra ulanmak üzere saklayın.
- **Next Preview:** Gelecek blokları önizleme özelliği.
- **Level & Score:** Seviye atladıkça hızlanan oyun ve puanlama sistemi.
- **Modern UI:** FluentAvalonia ile modern ve şık bir görünüm.
- **Klavye Kontrolleri:** Hassas ve akıcı oyun deneyimi.

## 🛠 Teknoloji Yığını
- **Framework:** [Avalonia UI](https://avaloniaui.net/)
- **Runtime:** [.NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Kütüphaneler:**
  - **CommunityToolkit.Mvvm:** MVVM mimarisi için.
  - **FluentAvaloniaUI:** Modern UI bileşenleri ve temalar.
  - **Velopack:** Uygulama güncelleme ve dağıtım yönetimi.

## 🎮 Kontroller
| Tuş | İşlem |
|-----|-------|
| ⬅️ / ➡️ | Sola / Sağa Hareket |
| ⬇️ | Hızlı Düşüş (Soft Drop) |
| ⬆️ | Döndür (Rotate clockwise) |
| Space | Sert Düşüş (Hard Drop) |
| C / Shift | Bloğu Sakla (Hold) |
| P | Duraklat (Pause) |

## 🛠 Kurulum ve Çalıştırma

### Gereksinimler
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Çalıştırma
Projeyi klonladıktan sonra ana dizinde terminal üzerinden şu komutu çalıştırabilirsiniz:

```bash
dotnet run
```

---
*Bu proje eğitim amaçlı geliştirilmiş olup, orijinal WPF sürümünün modern mimariye taşınması sürecini temsil eder.*
