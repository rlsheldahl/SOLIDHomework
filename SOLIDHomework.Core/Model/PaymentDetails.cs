using System;

namespace SOLIDHomework.Core.Model
{
    public class PaymentDetails
    {
        public string CardholderName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}