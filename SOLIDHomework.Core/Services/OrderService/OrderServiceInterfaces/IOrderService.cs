using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Services.OrderService
{
    public interface IOrderService
    {
        void Checkout(string username, ShoppingCartService shoppingCart, PaymentDetailsModel paymentDetails, bool notifyCustomer);
    }
}
