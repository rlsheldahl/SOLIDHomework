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
using SOLIDHomework.Core.Services;

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
            var notificationService = new NotificationService();

            
            // Create a new service collection
            var serviceCollection = new ServiceCollection();
            // Register services
            ConfigureServices(serviceCollection);
            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // Resolve the logger and use it
            var logger = serviceProvider.GetService<ILogger>();
            var _paymentService = serviceProvider.GetService<IPaymentService>();
            var _notificationService = serviceProvider.GetService<INotificationService>();
            var _IInventoryService = serviceProvider.GetService<IInventoryService>();
            OrderService orderService = new OrderService(paymentService, inventoryService, notificationService, logger);

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
            services.AddSingleton<ILogger, MyLogger>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IInventoryService, InventoryService>();
        }
    }
}
