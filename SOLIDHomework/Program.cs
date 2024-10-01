using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Builder;
using SOLIDHomework.Core.Interfaces;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Payment.PaymentInterfaces;
using SOLIDHomework.Core.Services;
using SOLIDHomework.Core.Services.EmailNotificationService;
using SOLIDHomework.Core.Services.EmailNotificationService.EmailNotificationServiceInterfaces;
using SOLIDHomework.Core.Services.InventoryService;
using SOLIDHomework.Core.Services.InventoryService.InventoryServiceInterfaces;
using SOLIDHomework.Core.Services.LoggerService.LoggerServiceInterfaces;
using SOLIDHomework.Core.Services.OrderService;

namespace SOLIDHomework
{
    public class Program
    {
        //Entry point to program
        //You don't have to change logic there
        //Tip: that is good place for composition root
        static void Main(string[] args)
        {
            var paymentService = new PaymentService();
            var inventoryService = new InventoryService();
            var notificationService = new EmailNotificationService();
            var loggerService = new LoggerService();

            
            // Create a new service collection
            var serviceCollection = new ServiceCollection();
            // Register services
            ConfigureServices(serviceCollection);
            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // Resolve the logger and use it
            var _logger = serviceProvider.GetService<ILoggerService>();
            var _paymentService = serviceProvider.GetService<IPaymentService>();
            var _notificationService = serviceProvider.GetService<IEmailNotificationService>();
            var _IInventoryService = serviceProvider.GetService<IInventoryService>();
            OrderService orderService = new OrderService(paymentService, inventoryService, notificationService, loggerService);

            var shoppingCartUnit = new ShoppingCartModelBuilder("US")
                .AddItem(new OrderItemModelBuilder()
                    .WithAmount(1)
                    .WithSeassonEndDate(DateTime.Now)
                    .WithCode("Test")
                    .WithPrice(10)
                    .WithType("Unit")
                    .Build())
                .Build();

            orderService.Checkout("TestUser", shoppingCartUnit, new PaymentDetailsModelBuilder()
                .WithCardholderName("haha")
                .WithCreditCardNumber("41111111111111")
                .WithExpiryDate(DateTime.Now.AddDays(10))
                .WithPaymentMethod(PaymentMethod.Cash)
                .Build(), true);

            var shoppingCartSpecial = new ShoppingCartModelBuilder("US")
                .AddItem(new OrderItemModelBuilder()
                    .WithAmount(1)
                    .WithSeassonEndDate(DateTime.Now)
                    .WithCode("Test")
                    .WithPrice(10)
                    .WithType("Special")
                    .Build())
                .Build();

            orderService.Checkout("TestUser2", shoppingCartSpecial, new PaymentDetailsModelBuilder()
                .WithCardholderName("haha2")
                .WithCreditCardNumber("41111111111112")
                .WithExpiryDate(DateTime.Now.AddDays(10))
                .WithPaymentMethod(PaymentMethod.Cash)
                .Build(), true);

            var shoppingCartWeight = new ShoppingCartModelBuilder("US")
                .AddItem(new OrderItemModelBuilder()
                    .WithAmount(1)
                    .WithSeassonEndDate(DateTime.Now)
                    .WithCode("Test")
                    .WithPrice(10)
                    .WithType("Weight")
                    .Build())
                .Build();

            orderService.Checkout("TestUser3", shoppingCartWeight, new PaymentDetailsModelBuilder()
                .WithCardholderName("haha3")
                .WithCreditCardNumber("41111111111113")
                .WithExpiryDate(DateTime.Now.AddDays(10))
                .WithPaymentMethod(PaymentMethod.Cash)
                .Build(), true);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IEmailNotificationService, EmailNotificationService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPayPalWebService, PayPalWebService>();
            services.AddScoped<IPayment, PayPalPayment>();

        }
    }
}
