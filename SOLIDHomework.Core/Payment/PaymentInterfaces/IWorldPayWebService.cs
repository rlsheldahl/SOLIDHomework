namespace SOLIDHomework.Core.Payment
{
    public class IWorldPayWebService
    {

        public string Charge(decimal amount, CreditCardModel creditCart, string bankID, string domenID)
        {
            return "Success";
        }
    }
}