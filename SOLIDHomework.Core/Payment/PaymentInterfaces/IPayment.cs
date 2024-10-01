using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Payment.PaymentInterfaces
{
    public interface IPayment
    {
        string Charge(decimal amount, CreditCardModel creditCard);
    }
}
