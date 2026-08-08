namespace PaymentGatewayService.Models
{
    public enum TransactionType
    {
        Sale = 1,       # Doğrudan Satış (Ödeme alma)
        PreAuth = 2,    # Ön Provizyon (Limiti bloke etme)
        PostAuth = 3,   # Ön Provizyon Kapama (Parayı çekme)
        Void = 4,       # İptal (Gün sonu yapılmadan önceki iptal)
        Refund = 5      # İade (Gün sonu alındıktan sonraki iade)
    }

    public enum PaymentStatus
    {
        Success = 1,
        Failed = 2,
        Requires3DS = 3,
        PendingReconciliation = 4
    }
}
