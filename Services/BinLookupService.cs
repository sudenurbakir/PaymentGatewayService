using PaymentGatewayService.Models;

namespace PaymentGatewayService.Services
{
    public class BinDetail
    {
        public string BankName { get; set; }
        public bool IsCreditCard { get; set; }       // true: Kredi Kartı, false: Banka Kartı (Debit)
        public bool IsCommercialCard { get; set; }   // Ticari Kart (Taksit kısıtı farklıdır)
        public int MaxInstallmentAllowed { get; set; }
    }

    public class BinLookupService
    {
        public BinDetail GetBinDetail(string binNumber)
        {
            if (string.IsNullOrEmpty(binNumber) || binNumber.Length < 6)
            {
                throw new ArgumentException("Geçersiz BIN numarası. En az 6 hane olmalıdır.");
            }

            // Örnek BIN Mock Mantığı (Gerçek hayatta BIN veritabanından sorgulanır)
            if (binNumber.StartsWith("589004")) 
            {
                // Banka Kartı (Debit) - Taksit Yapılamaz
                return new BinDetail { BankName = "Akbank", IsCreditCard = false, IsCommercialCard = false, MaxInstallmentAllowed = 1 };
            }
            else if (binNumber.StartsWith("554960")) 
            {
                // Bireysel Kredi Kartı - Max 12 Taksit
                return new BinDetail { BankName = "Garanti", IsCreditCard = true, IsCommercialCard = false, MaxInstallmentAllowed = 12 };
            }

            // Varsayılan Bireysel Kart
            return new BinDetail { BankName = "Diğer", IsCreditCard = true, IsCommercialCard = false, MaxInstallmentAllowed = 6 };
        }
    }
}
