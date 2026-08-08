### TransactionType ve PaymentStatus

Bu enum'lar ödeme işlemlerinde kullanılabilecek **işlem türlerini ve ödeme durumlarını** tanımlar.

* **TransactionType:** Gerçekleştirilen işlemin türünü belirtir.

  * `Sale` → Doğrudan ödeme alma
  * `PreAuth` → Ön provizyon / tutarı bloke etme
  * `PostAuth` → Ön provizyonu kapatma ve tutarı tahsil etme
  * `Void` → Gün sonu öncesi işlem iptali
  * `Refund` → Tamamlanmış işlem sonrası iade

* **PaymentStatus:** Ödeme işleminin mevcut durumunu belirtir.

  * `Success` → Başarılı
  * `Failed` → Başarısız
  * `Requires3DS` → 3D Secure doğrulaması gerekli
  * `PendingReconciliation` → Mutabakat bekleniyor

Enum içerisindeki `1, 2, 3...` değerleri, sistemin veya entegre olunan ödeme kuruluşunun belirlediği **işlem kodlarını** temsil eder. Sanal POS entegrasyonlarında bu kodlar genellikle entegrasyon dokümanında tanımlanır.
