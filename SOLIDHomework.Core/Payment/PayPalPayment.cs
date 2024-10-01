using SOLIDHomework.Core.Payment.PaymentInterfaces;

namespace SOLIDHomework.Core.Payment
{
    public class PayPalPayment : IPayment
    {
        private readonly IPayPalWebService _payPalWebService;

        public PayPalPayment(IPayPalWebService payPalWebService)
        {
            _payPalWebService = payPalWebService;
        }
        public PayPalPayment(string appSetting, string s)
        {
            throw new System.NotImplementedException();
        }

        //required for Auth;
        public string AccountName { get; set; }
        public string Password { get; set; }

        public string Charge(decimal amount, CreditCardModel creditCard)
        {
            string token = _payPalWebService.GetTransactionToken(AccountName, Password);
            string response = _payPalWebService.Charge(amount, token, creditCard);
            return response;

            /*
            PayPalWebService payPalWebService = new PayPalWebService();
            string token = payPalWebService.GetTransactionToken(AccountName, Password);
            string response = payPalWebService.Charge(amount, token, creditCart);
            return response;
            */
        }
    }
}