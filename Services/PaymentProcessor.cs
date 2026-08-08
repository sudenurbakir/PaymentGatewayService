using PaymentGatewayService.Models;

namespace PaymentGatewayService.Services
{
    public class PaymentProcessor
    {
        private readonly BinLookupService _binLookupService;

        public PaymentProcessor()
        {
            _binLookupService = new BinLookupService();
        }

        /// 
        /// Ödeme isteğini işler, BIN kontrollerini yapar ve 3D Secure yönlendirme kararını verir.
        /// 
        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            var response = new PaymentResponse
            {
                PaidAmount = request.Amount,
                Installment = request.Installment
            };

            // 1. İş Kuralı: BIN ve Taksit Kontrolü
            var binDetail = _binLookupService.GetBinDetail(request.CardBin);
            if (!binDetail.IsCreditCard && request.Installment > 1)
            {
                response.Status = PaymentStatus.Failed;
                response.ErrorCode = "400_DEBIT_NO_INSTALLMENT";
                response.ErrorMessage = "Banka kartlarına (Debit) taksit yapılamaz.";
                return response;
            }

            if (request.Installment > binDetail.MaxInstallmentAllowed)
            {
                response.Status = PaymentStatus.Failed;
                response.ErrorCode = "400_EXCEEDS_MAX_INSTALLMENT";
                response.ErrorMessage = $"Bu kart için maksimum {binDetail.MaxInstallmentAllowed} taksit seçilebilir.";
                return response;
            }

            // 2. İş Kuralı: 3D Secure Zorunluluğu (3000 TL Üzeri Risk Kuralı)
            if (request.Amount >= 3000.00m && !request.Is3DSecure)
            {
                response.Status = PaymentStatus.Requires3DS;
                response.ErrorMessage = "3000 TL ve üzeri işlemler 3D Secure zorunludur.";
                response.HtmlContent = "...";
                return response;
            }

            // 3. İş Kuralı: Başarılı Provizyon Simülasyonu
            response.Status = PaymentStatus.Success;
            response.TransactionId = "TRX_" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
            response.AuthCode = "AUTH_" + Random.Shared.Next(100000, 999999);
            return response;
        }

        /// 
        /// Gün Sonu (Batch Close) durumuna göre İptal (Void) veya İade (Refund) kararı verir.
        /// 
        public PaymentResponse ProcessCancelOrRefund(string transactionId, bool isBatchClosed, decimal refundAmount)
        {
            if (!isBatchClosed)
            {
                // Gün Sonu Alınmamış -> İPTAL (Void)
                return new PaymentResponse
                {
                    TransactionId = transactionId,
                    Status = PaymentStatus.Success,
                    ErrorMessage = "İşlem gün sonu alınmadığı için İPTAL (Void) edildi. Ekstreye yansımaz."
                };
            }
            else
            {
                // Gün Sonu Alınmış -> İADE (Refund)
                return new PaymentResponse
                {
                    TransactionId = transactionId,
                    Status = PaymentStatus.Success,
                    PaidAmount = refundAmount,
                    ErrorMessage = $"{refundAmount} TL tutarındaki İADE (Refund) işlemi bankaya iletildi."
                };
            }
        }
    }
}
