using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Payment.PaymentInterfaces
{
    public interface IPayPalWebService
    {
        string GetTransactionToken(string accountName, string password);
        string Charge(decimal amount, string token, CreditCardModel creditCard);
    }
}
