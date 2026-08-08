# 3D Secure Ödeme & Provizyon Akış Diyagramı

mermaid
graph TD
A[Müşteri Kart Bilgilerini Girer] --> B[BIN Sorgusu: BinLookupService]
B --> C{Kart Tipi Nedir?}
C -- Banka Kartı (Debit) & Taksit > 1 --> D[Hata: Banka kartına taksit yapılamaz]
C -- Kredi Kartı --> E{Tutar >= 3000 TL mi?}

E -- Evet --> F[3D Secure Zorunlu: Banka OTP Sayfasına Yönlendir]
E -- Hayır --> G{Müşteri 3DS Seçti mi?}

G -- Evet --> F
G -- Hayır --> H[Doğrudan Provizyon İsteği (Direct API)]

F --> I{OTP SMS Doğrulaması Başarılı mı?}
I -- Hayır --> J[Ödeme Reddedildi: 3DS Hatalı]
I -- Evet --> H

H --> K{Banka Yanıtı}
K -- Yetersiz Bakiye (Code: 51) --> L[Ödeme Reddedildi]
K -- Onaylandı (Code: 00) --> M[Sipariş Onaylandı: AuthCode Üretildi]
