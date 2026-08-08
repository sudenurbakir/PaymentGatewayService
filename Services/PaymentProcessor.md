### PaymentProcessor

`PaymentProcessor`, ödeme işlemini yöneten ve ilgili iş kurallarını uygulayan servistir.

* **BIN ve Taksit Kontrolü:** Debit kartlara taksit uygulanamaz ve kartın maksimum taksit limiti aşılamaz.
* **3D Secure Kontrolü:** 3000 TL ve üzerindeki işlemlerde 3D Secure zorunludur.
* **Ödeme Sonucu:** Tüm kontroller başarılıysa ödeme `Success` olarak sonuçlandırılır ve örnek bir `TransactionId` ile `AuthCode` oluşturulur.
* **İptal / İade:** Gün sonu alınmadan yapılan işlemler `Void (İptal)`, gün sonu alındıktan sonraki işlemler `Refund (İade)` olarak değerlendirilir.

**Özet:** Servis, ödeme isteğini doğrular, iş kurallarını uygular ve ödeme ile iptal/iade işlemlerinin sonucunu belirler.
