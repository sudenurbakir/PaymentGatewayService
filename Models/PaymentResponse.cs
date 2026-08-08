namespace PaymentGatewayService.Models
{
    public class PaymentResponse
    {
        public string TransactionId { get; set; }     // Bankadan dönen eşsiz işlem numarası
        public string AuthCode { get; set; }          // Otorizasyon / Provizyon kodu
        public PaymentStatus Status { get; set; }     // Success, Failed, Requires3DS
        public string ErrorCode { get; set; }         // Örn: "51" (Yetersiz Bakiye), "54" (Miyadı Dolmuş Kart)
        public string ErrorMessage { get; set; }       // Müşteriye gösterilecek hata açıklaması
        public decimal PaidAmount { get; set; }
        public int Installment { get; set; }
        public string HtmlContent { get; set; }       // 3D Secure yönlendirmesi için banka HTML formu
    }
}
