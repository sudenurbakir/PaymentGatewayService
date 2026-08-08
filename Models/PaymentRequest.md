### PaymentRequest

`PaymentRequest`, ödeme işlemi başlatılırken gerekli bilgileri taşıyan request modelidir.

İçerisinde sipariş numarası, ödeme tutarı, para birimi, taksit sayısı, kart bilgilerine ait token/BIN, 3D Secure tercihi ve işlem tipi gibi alanlar bulunur.

* `OrderId` → Sipariş numarası
* `Amount` → Ödeme tutarı
* `Currency` → Para birimi (`TRY`)
* `Installment` → Taksit sayısı
* `CardBin` → Kartın ilk 6 hanesi
* `CardToken` → Saklı kart/token bilgisi
* `Is3DSecure` → 3D Secure kullanımı
* `Type` → İşlem tipi (`Sale`, `Refund` vb.)

Varsayılan olarak para birimi `TRY`, taksit sayısı `1` ve işlem tipi `Sale` olarak belirlenmiştir.
