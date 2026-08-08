namespace PaymentGatewayService.Models
{
    public class PaymentRequest
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "TRY";
        public int Installment { get; set; } = 1;     // Taksit Sayısı (1 = Tek Çekim)
        public string CardBin { get; set; }            // Kartın İlk 6 Hanesi
        public string CardToken { get; set; }          // Saklı Kart Anahtarı (PCI-DSS)
        public bool Is3DSecure { get; set; } = true;   // 3D Secure Zorunluluğu
        public TransactionType Type { get; set; } = TransactionType.Sale;
    }
}
