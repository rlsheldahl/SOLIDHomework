using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core
{
    //Order - check inventory, charge money for credit card and online payments, 
    //tips:
    //think about SRP, DI, OCP
    //maybe for each type of payment type make sense to have own Order-based class?

    public class OrderService
    {
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly CustomerNotifier _customerNotifier;

        public void Checkout(string username, ShoppingCart shoppingCart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard || paymentDetails.PaymentMethod == PaymentMethod.OnlineOrder)
            {
                _paymentService.Charge(paymentDetails, shoppingCart);
            }
            var inventoryService = new InventoryService();
            inventoryService.ReserveInventory(shoppingCart);
            if (paymentDetails.PaymentMethod == PaymentMethod.OnlineOrder && notifyCustomer)
            {
                _customerNotifier.NotifyCustomer(username);
            }

            MyLogger logger = new MyLogger();
            logger.Write("Success checkout");
        }
    }
}
