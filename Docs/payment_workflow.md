# 3D Secure Odeme ve Provizyon Akis Diyagrami

Bu dokuman, PaymentGatewayService icerisindeki 3D Secure ve kart kısıt kurallarını gorsellestirmektedir.

```mermaid
flowchart TD
    A[Musteri Kart Bilgilerini Girer] --> B[BIN Sorgusu Yapilir]
    
    B --> C{Kart Tipi Nedir?}
    C -- Banka Kartı ve Taksit Var --> D[Hata: Banka kartina taksit yapilamaz]
    C -- Kredi Kartı --> E{Tutar 3000 TL uzeri mi?}
    
    E -- Evet --> F[3D Secure Sayfasina Yonlendir]
    E -- Hayir --> G{Musteri 3D Secure Secti mi?}
    
    G -- Evet --> F
    G -- Hayir --> H[Bankaya Dogrudan Odeme Istegi At]
    
    F --> I{SMS Kodu Dogru mu?}
    I -- Hayir --> J[Odeme Reddedildi]
    I -- Evet --> H
    
    H --> K{Banka Yaniti}
    K -- Yetersiz Bakiye --> L[Odeme Reddedildi]
    K -- Onaylandi --> M[Siparis Onaylandi]
