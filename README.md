# Payment Gateway & Sanal POS Entegrasyon Servisi

Bu proje; bir e-ticaret sistemindeki **Sanal POS**, **3D Secure doğrulama**, **BIN sorgulama**, **Kart Saklama (Tokenization)** ve **Gün Sonu Mutabakat (Void vs. Refund)** süreçlerinin bir **İş Analisti** perspektifiyle C#, BDD (Gherkin), SQL ve Mermaid akış diyagramları kullanılarak kurgulandığı uçtan uca bir entegrasyon çalışmasıdır.

---
# İş Analizi & Ödeme Sistemi Kuralları

## 1. BIN Sorgulama & Taksit Kısıtları

**Dosya:** `Services/BinLookupService.cs`

Kart numarasının ilk 6 hanesi olan **BIN** üzerinden kartın ait olduğu banka ve kart tipi (Kredi Kartı / Debit) belirlenir.

**İş Kuralları:**

* Banka kartlarına (Debit) taksit uygulanamaz.
* Kart tipine göre maksimum taksit sayısı sınırlandırılır.

---

## 2. Risk Kuralı & 3D Secure Yönlendirmesi

**Dosya:** `Services/PaymentProcessor.cs`

* 3000 TL ve üzerindeki işlemlerde **3D Secure doğrulaması** zorunludur.
* Tutar ve 3D Secure durumuna göre ödeme işlemi yönlendirilir.
* Gerekli durumda müşterinin bankanın güvenli ödeme ekranına yönlendirilmesi için HTML içerik oluşturulur.

---

## 3. Gün Sonu Mutabakatı: Void vs. Refund

### Void — İptal

* Gün sonu (Batch Close) alınmadan önce gerçekleştirilen işlem iptalidir.
* İşlem henüz gün sonu sürecine dahil olmadığı için iptal işlemi olarak değerlendirilir.

### Refund — İade

* Gün sonu alındıktan sonra gerçekleştirilen para iadesidir.
* Tam veya kısmi iade işlemleri için kullanılabilir.

**Temel Kural:**

```text
Gün sonu alınmadı → VOID (İptal)
Gün sonu alındı    → REFUND (İade)
```

---

## 4. PCI-DSS Uyumlu Kart Saklama (Tokenization)

**Dosya:** `SQL/create_payment_tables.sql`

Hassas kart verilerinin (PAN/CVV) doğrudan veritabanında saklanması yerine **CardToken** kullanılır.

Kart bilgileri yerine token ve maskelenmiş kart bilgileri kullanılarak ödeme işlemlerinin daha güvenli şekilde yürütülmesi amaçlanır.

---

## Süreç Akış Şeması (Workflow)

Ödeme, BIN kontrolü, taksit kuralları, 3D Secure ve Void/Refund karar mekanizmalarının süreç akışı:

`Docs/payment_workflow.md`

Bu dosyada süreç **Mermaid.js** diyagramı ile görselleştirilmiştir.

## Proje Mimari Yapısı

Proje, ödeme sistemindeki **veri modelleri, iş kuralları, test senaryoları, veritabanı işlemleri ve süreç dokümantasyonunu** ayrı katmanlarda yönetmek amacıyla yapılandırılmıştır.

```text
PaymentGatewayService/
├── Models/                         # Veri modelleri ve DTO'lar
│   ├── PaymentRequest.cs           # Ödeme istek modeli
│   ├── PaymentResponse.cs          # Ödeme yanıt modeli
│   └── TransactionType.cs          # İşlem tipleri
│
├── Services/                       # Ödeme iş kuralları
│   ├── BinLookupService.cs         # BIN, banka ve taksit kontrolleri
│   └── PaymentProcessor.cs         # Ödeme, 3D Secure ve Void/Refund işlemleri
│
├── Tests/                          # BDD kabul kriterleri
│   ├── Payment3DSecure.feature     # 3D Secure ve taksit senaryoları
│   └── VoidVsRefund.feature        # Void ve Refund senaryoları
│
├── SQL/                            # Veritabanı ve raporlama
│   ├── create_payment_tables.sql   # Ödeme ve Tokenization tabloları
│   └── reconciliation_queries.sql  # Mutabakat ve raporlama sorguları
│
└── Docs/                           # Süreç dokümantasyonu
    └── payment_workflow.md         # Ödeme süreç akış diyagramı
```

### Klasörlerin Sorumlulukları

* **Models:** Ödeme sırasında kullanılan request, response ve işlem tipi modellerini içerir.
* **Services:** BIN, taksit, 3D Secure, ödeme ve Void/Refund gibi iş kurallarını yönetir.
* **Tests:** İş kurallarının kabul kriterlerini ve BDD senaryolarını içerir.
* **SQL:** Ödeme veritabanı tabloları ve mutabakat/raporlama sorgularını içerir.
* **Docs:** Ödeme sürecinin görsel akışını ve teknik dokümantasyonunu içerir.


