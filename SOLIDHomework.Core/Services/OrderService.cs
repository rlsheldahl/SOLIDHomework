using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SOLIDHomework.Core.Interfaces;
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
        private readonly IPaymentService _paymentService;
        private readonly IInventoryService _inventoryService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;

        public OrderService(IPaymentService paymentService, IInventoryService inventoryService, INotificationService notificationService, ILogger logger)
        {
            _paymentService = paymentService;
            _inventoryService = inventoryService;
            _notificationService = notificationService;
            _logger = logger;
        }

        public void Checkout(string username, ShoppingCart shoppingCart, PaymentDetailsModel paymentDetails, bool notifyCustomer)
        {
            _paymentService.ProcessPayment(paymentDetails, shoppingCart);
            _inventoryService.ReserveInventory(shoppingCart);

            if (notifyCustomer)
            {
                _notificationService.NotifyCustomer(username);
            }

            _logger.Info("Success checkout");
        }
    }
}
