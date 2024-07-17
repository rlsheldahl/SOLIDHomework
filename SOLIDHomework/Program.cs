using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Model;

namespace SOLIDHomework
{
    public class Program
    {
        //Entry point to program
        //You don't have to change logic there
        //Tip: that is good place for composition root
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            var UnitDiscountStrategy = new UnitDiscountStrategy();
            var SpecialDiscountStrategy = new SpecialDiscountStrategy();
            var WeightStrategy = new WeightStrategy();
            ShoppingCart shoppingCartUnit = new ShoppingCart("US", UnitDiscountStrategy);
            shoppingCartUnit.Add(new OrderItem()
                {
                    Amount = 1,
                    SeasonEndDate =  DateTime.Now,
                    Code =  "Test",
                    Price =  10,
                    Type = "Unit"
                });
            orderService.Checkout("TestUser",shoppingCartUnit,new PaymentDetails()
                {
                   CardholderName = "haha1",
                   CreditCardNumber =  "41111111111111",
                   ExpiryDate =  DateTime.Now.AddDays(10),
                   PaymentMethod = PaymentMethod.Cash
                },true);
            ShoppingCart shoppingCartSpecial = new ShoppingCart("US", SpecialDiscountStrategy);
            shoppingCartSpecial.Add(new OrderItem()
            {
                Amount = 1,
                SeasonEndDate = DateTime.Now,
                Code = "Test",
                Price = 10,
                Type = "Special"
            });
            orderService.Checkout("TestUser", shoppingCartSpecial, new PaymentDetails()
            {
                CardholderName = "haha2",
                CreditCardNumber = "41111111111112",
                ExpiryDate = DateTime.Now.AddDays(10),
                PaymentMethod = PaymentMethod.Cash
            }, true);
            ShoppingCart shoppingCartWeight = new ShoppingCart("US", WeightStrategy);
            shoppingCartSpecial.Add(new OrderItem()
            {
                Amount = 1,
                SeasonEndDate = DateTime.Now,
                Code = "Test",
                Price = 10,
                Type = "Weight"
            });
            orderService.Checkout("TestUser", shoppingCartWeight, new PaymentDetails()
            {
                CardholderName = "haha3",
                CreditCardNumber = "41111111111113",
                ExpiryDate = DateTime.Now.AddDays(10),
                PaymentMethod = PaymentMethod.Cash
            }, true);
        }
    }
}
