using SOLIDHomework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces
{
    public interface IPaymentDetailsModelBuilder
    {
        IPaymentDetailsModelBuilder WithCardholderName(string name);
        IPaymentDetailsModelBuilder WithCreditCardNumber(string number);
        IPaymentDetailsModelBuilder WithExpiryDate(DateTime date);
        IPaymentDetailsModelBuilder WithPaymentMethod(PaymentMethod method);
        PaymentDetailsModel Build();
    }
}
