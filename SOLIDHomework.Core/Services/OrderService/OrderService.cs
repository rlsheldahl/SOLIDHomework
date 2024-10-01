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
using SOLIDHomework.Core.Services.EmailNotificationService.EmailNotificationServiceInterfaces;
using SOLIDHomework.Core.Services.InventoryService.InventoryServiceInterfaces;
using SOLIDHomework.Core.Services.LoggerService.LoggerServiceInterfaces;

namespace SOLIDHomework.Core.Services.OrderService
{
    //Order - check inventory, charge money for credit card and online payments, 
    //tips:
    //think about SRP, DI, OCP
    //maybe for each type of payment type make sense to have own Order-based class?
    public class OrderService : IOrderService
    { 
        private readonly IPaymentService _paymentService;
        private readonly IInventoryService _inventoryService;
        private readonly IEmailNotificationService _notificationService;
        private readonly ILoggerService _logger;

        public OrderService(IPaymentService paymentService, IInventoryService inventoryService, IEmailNotificationService notificationService, ILoggerService logger)
        {
            _paymentService = paymentService;
            _inventoryService = inventoryService;
            _notificationService = notificationService;
            _logger = logger;
        }

        public void Checkout(string username, ShoppingCartService shoppingCart, PaymentDetailsModel paymentDetails, bool notifyCustomer)
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