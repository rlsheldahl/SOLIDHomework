using SOLIDHomework.Core.Payment.PaymentInterfaces;

namespace SOLIDHomework.Core.Payment
{
    public class PayPalWebService : IPayPalWebService
    {
        //web based service
        public string GetTransactionToken(string accountName, string password)
        {
            return "Something";
        }

        public string Charge(decimal amount, string token, CreditCardModel creditCart)
        {
            return "200OK";
        }
    }
}