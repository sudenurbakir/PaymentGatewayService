### PaymentResponse

`PaymentResponse`, ödeme işlemi sonrasında banka veya ödeme kuruluşundan dönen bilgileri temsil eder.

* `TransactionId` → Bankanın oluşturduğu benzersiz işlem numarası
* `AuthCode` → Provizyon/otorizasyon kodu
* `Status` → Ödeme durumu (`Success`, `Failed`, `Requires3DS` vb.)
* `ErrorCode` → İşlem başarısızsa dönen hata kodu
* `ErrorMessage` → Hata açıklaması
* `PaidAmount` → Gerçekleşen ödeme tutarı
* `Installment` → Taksit sayısı
* `HtmlContent` → 3D Secure yönlendirmesi için kullanılabilecek HTML içeriği

**Özet:** `PaymentRequest` ödeme kuruluşuna gönderilen bilgileri, `PaymentResponse` ise ödeme kuruluşundan dönen işlem sonucunu temsil eder.
