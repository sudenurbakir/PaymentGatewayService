Feature: İptal (Void) ve İade (Refund) İşlem Kuralları
  Müşteri ve mağaza taleplerine göre gün sonu mutabakat durumuna bakılarak
  işlemin İptal (Void) mi yoksa İade (Refund) mü olacağının belirlenmesi.

  Scenario: Gün Sonu Alınmadan Önce Yapılan İşlem İptal (Void) Edilmelidir
    Given "TRX100200" ID'li başarılı bir ödeme işlemi mevcuttur
    And İşlemin ait olduğu gün sonu (Batch Close) henüz "ALINMAMIŞTIR"
    When Müşteri işlemi iptal etmek istediğinde
    Then İşlem tipi "Void" olarak bankaya gönderilmelidir
    And Müşteri kartındaki provizyon blokajı kaldırılmalıdır (Ekstreye yansımaz)

  Scenario: Gün Sonu Alındıktan Sonra Yapılan İşlem İade (Refund) Edilmelidir
    Given "TRX100200" ID'li 500.00 TL tutarında ödeme işlemi mevcuttur
    And İşlemin ait olduğu gün sonu (Batch Close) "ALINMIŞTIR"
    When Müşteri 200.00 TL tutarında kısmi iade talep ettiğinde
    Then İşlem tipi "Refund" olarak bankaya gönderilmelidir
    And Müşteri hesabına 200.00 TL tutarında iade kaydı geçilmelidir
