Feature: Sanal POS 3D Secure Ödeme ve BIN Yönetimi
  Müşterinin kart bilgilerine göre doğru banka entegrasyonunun çağrılması
  ve 3D Secure doğrulamasının güvenle yapılması gerekmektedir.

  Scenario Outline: Kart BIN Numarasına Göre Taksit ve Banka Tespiti
    Given Müşteri ödeme sayfasına kart numarasının ilk 6 hanesini "" olarak girer
    When Sistem BIN sorgusunu tamamladığında
    Then Kartın bankası "" ve tipi "" olarak tespit edilmelidir
    And Maksimum izin verilen taksit sayısı  olmalıdır

    Examples:
      | BIN    | Banka     | KartTipi    | MaksTaksit |
      | 554960 | Garanti   | Kredi Kartı | 12         |
      | 454360 | Yapı Kredi| Kredi Kartı | 9          |
      | 589004 | Akbank    | Banka Kartı | 1          |

  Scenario: 3000 TL Üzeri İşlemlerde 3D Secure Zorunluluğu
    Given Ödeme tutarı 3500.00 TL'dir
    When Müşteri ödeme isteği gönderdiğinde
    Then İşlem tipi "Requires3DS" durumuna geçmelidir
    And Müşteri bankanın OTP (SMS Kod) sayfasına yönlendirilmelidir
