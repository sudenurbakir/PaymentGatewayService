-- 1. Gün Sonu Alınmamış İptal Edilebilir (Void) İşlemlerin Listesi
SELECT 
    TransactionId,
    OrderId,
    Amount,
    CreatedDate
FROM PaymentTransactions
WHERE Status = 'Success' 
  AND IsBatchClosed = 0;

-- 2. Banka Mutabakat Özeti (Günlük Toplam Ciro ve Taksit Dağılımı)
SELECT 
    Installment AS TaksitSayisi,
    COUNT(TransactionId) AS IslemAdedi,
    SUM(Amount) AS ToplamCiro
FROM PaymentTransactions
WHERE Status = 'Success' 
  AND CAST(CreatedDate AS DATE) = CAST(GETDATE() AS DATE)
GROUP BY Installment;
