### Ödeme İşlemleri SQL Sorguları

**1. Void Edilebilir İşlemler:**
Başarılı olmuş ve henüz gün sonu alınmamış (`IsBatchClosed = 0`) işlemleri listeler. Bu işlemler **Void (İptal)** edilebilir. İşlem numarası, sipariş numarası, tutar ve işlem tarihi bilgilerini getirir.

**2. Günlük Ciro ve Taksit Raporu:**
Bugünkü başarılı ödeme işlemlerini (`Status = 'Success'`) taksit sayısına göre gruplar. Her taksit grubu için:

* `COUNT()` → İşlem adedini
* `SUM()` → Toplam ciroyu

hesaplar.

**Özet:** İlk sorgu operasyonel olarak iptal edilebilir işlemleri bulurken, ikinci sorgu günlük ödeme ve ciro analizinde kullanılır.
