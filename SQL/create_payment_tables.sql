-- 1. Kart Saklama (Tokenization) Tablosu - PCI-DSS Uyumlu
CREATE TABLE SavedCardTokens (
    TokenId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    CardToken VARCHAR(255) NOT NULL UNIQUE, -- Maskelenmiş banka anahtarı
    MaskedPan VARCHAR(19) NOT NULL,        -- Örn: "5549 **** **** 1234"
    CardHolderName VARCHAR(100) NOT NULL,
    ExpireMonth VARCHAR(2) NOT NULL,
    ExpireYear VARCHAR(4) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- 2. Ödeme İşlemleri Tablosu (Payment Transactions)
CREATE TABLE PaymentTransactions (
    TransactionId VARCHAR(50) PRIMARY KEY,
    OrderId VARCHAR(50) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Installment INT DEFAULT 1,
    TransactionType VARCHAR(20) NOT NULL, -- Sale, PreAuth, Void, Refund
    Status VARCHAR(20) NOT NULL,          -- Success, Failed, Requires3DS
    AuthCode VARCHAR(20),
    ErrorCode VARCHAR(50),
    IsBatchClosed BIT DEFAULT 0,          -- 0: Gün Sonu Alınmadı (Void yapılabilir), 1: Alındı (Refund yapılır)
    CreatedDate DATETIME DEFAULT GETDATE()
);
