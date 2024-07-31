using SOLIDHomework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public class PaymentDetailsBuilder
    {
        private PaymentDetails _paymentDetails;

        public PaymentDetailsBuilder()
        {
            _paymentDetails = new PaymentDetails();
        }

        public PaymentDetailsBuilder WithCardholderName(string name)
        {
            _paymentDetails.CardholderName = name;
            return this;
        }

        public PaymentDetailsBuilder WithCreditCardNumber(string number)
        {
            _paymentDetails.CreditCardNumber = number;
            return this;
        }

        public PaymentDetailsBuilder WithExpiryDate(DateTime date)
        {
            _paymentDetails.ExpiryDate = date;
            return this;
        }

        public PaymentDetailsBuilder WithPaymentMethod(PaymentMethod method)
        {
            _paymentDetails.PaymentMethod = method;
            return this;
        }

        public PaymentDetails Build()
        {
            return _paymentDetails;
        }
    }
}
