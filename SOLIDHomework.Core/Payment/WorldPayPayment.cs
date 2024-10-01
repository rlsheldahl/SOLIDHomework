using SOLIDHomework.Core.Payment.PaymentInterfaces;

namespace SOLIDHomework.Core.Payment
{
    public class WorldPayPayment : IWorldPayWebService
    {
        public WorldPayPayment(string appSetting)
        {
            throw new System.NotImplementedException();
        }

        //required for Auth;
        public string BankID { get; set; }
        public string DomenID { get; set; }

        public string Charge(decimal amount, CreditCardModel creditCart)
        {
            IWorldPayWebService worldPayWebService = new IWorldPayWebService();
            string response = worldPayWebService.Charge(amount, creditCart, BankID, DomenID);
            return response;
        }
    }
}