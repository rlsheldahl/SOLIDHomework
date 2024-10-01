using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public class PaymentDetailsModelBuilder : IPaymentDetailsModelBuilder
    {
        private PaymentDetailsModel _paymentDetails;

        public PaymentDetailsModelBuilder()
        {
            _paymentDetails = new PaymentDetailsModel();
        }

        public IPaymentDetailsModelBuilder WithCardholderName(string name)
        {
            _paymentDetails.CardholderName = name;
            return this;
        }

        public IPaymentDetailsModelBuilder WithCreditCardNumber(string number)
        {
            _paymentDetails.CreditCardNumber = number;
            return this;
        }

        public IPaymentDetailsModelBuilder WithExpiryDate(DateTime date)
        {
            _paymentDetails.ExpiryDate = date;
            return this;
        }

        public IPaymentDetailsModelBuilder WithPaymentMethod(PaymentMethod method)
        {
            _paymentDetails.PaymentMethod = method;
            return this;
        }

        public PaymentDetailsModel Build()
        {
            return _paymentDetails;
        }
    }
}
