# Payment Gateway & Sanal POS Entegrasyon Servisi

Bu proje; bir e-ticaret sistemindeki **Sanal POS**, **3D Secure doğrulama**, **BIN sorgulama**, **Kart Saklama (Tokenization)** ve **Gün Sonu Mutabakat (Void vs. Refund)** süreçlerinin bir **İş Analisti** perspektifiyle C#, BDD (Gherkin), SQL ve Mermaid akış diyagramları kullanılarak kurgulandığı uçtan uca bir entegrasyon çalışmasıdır.

---

## 📁 Proje Mimari Yapısı (Project Architecture)

```text
PaymentGatewayService/
├── Models/                     # DTO'lar & Veri Modelleri
│   ├── PaymentRequest.cs       # Ödeme istek modeli (Kart, BIN, Tutar, Taksit)
│   ├── PaymentResponse.cs      # Banka yanıt modeli (TransactionId, AuthCode, Status)
│   └── TransactionType.cs      # İşlem tipleri (Sale, PreAuth, Void, Refund)
├── Services/                   # Sanal POS İş Kuralları Servisleri
│   ├── BinLookupService.cs     # Kartın ilk 6 hanesinden banka ve taksit bulma
│   └── PaymentProcessor.cs     # 3D Secure doğrulama ve İptal/İade kuralları
├── Tests/                      # BDD Kabul Kriterleri (Gherkin)
│   ├── Payment3DSecure.feature # 3D Secure ve Taksit BDD senaryoları
│   └── VoidVsRefund.feature    # İptal (Void) ve İade (Refund) kabul kriterleri
├── SQL/                        # Veritabanı & Mutabakat Sorguları
│   ├── create_payment_tables.sql  # İşlem kayıtları ve Tokenization (PCI-DSS) tablosu
│   └── reconciliation_queries.sql # Gün sonu mutabakat ve raporlama sorguları
└── Docs/                       # Süreç Akış Şeması
    └── payment_workflow.md     # Mermaid 3D Secure ödeme akış şeması
