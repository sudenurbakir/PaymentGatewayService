### Veritabanı Tabloları

**SavedCardTokens:**
Müşterilerin kayıtlı kartlarını doğrudan kart numarası yerine **token ve maskelenmiş kart bilgileri** üzerinden saklamak için kullanılır. Kartın hangi kullanıcıya ait olduğu, kart sahibi, son kullanma tarihi ve token bilgisi tutulur. Bu yapı ödeme kartı verilerinin güvenli şekilde yönetilmesine yardımcı olur.

**PaymentTransactions:**
Gerçekleştirilen ödeme işlemlerinin kayıtlarını tutar. İşlem numarası, sipariş, tutar, taksit, işlem tipi (`Sale`, `PreAuth`, `Void`, `Refund`), ödeme durumu, provizyon kodu ve hata bilgileri gibi alanları içerir.

`IsBatchClosed` alanı, gün sonu durumunu belirtir:

* `0` → Gün sonu alınmamış → **Void (İptal)**
* `1` → Gün sonu alınmış → **Refund (İade)**

**Özet:** `SavedCardTokens` kayıtlı kart bilgilerini, `PaymentTransactions` ise ödeme işlemlerinin geçmişini ve durumunu tutar.
