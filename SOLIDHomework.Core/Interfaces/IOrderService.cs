using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Interfaces
{
    public interface IOrderService
    {
        void Checkout(string username, ShoppingCart shoppingCart, PaymentDetailsModel paymentDetails, bool notifyCustomer);
    }
}
