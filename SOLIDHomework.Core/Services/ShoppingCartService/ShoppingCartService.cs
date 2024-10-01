using SOLIDHomework.Core.Interfaces;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services.ShoppingCartService.ShoppingCartServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Services.ShoppingCartService
{
    //there are OCP and SOC violation
    //
    public class ShoppingCartService : IShoppingCartService
    {
        private ITaxCalculatorService _taxCalculatorService { get; set; }
        private readonly List<IOrderItemModel> orderItems;
        private readonly IDiscountStrategy discountStrategy;
        private readonly ITaxCalculatorService taxCalculator;

        public ShoppingCartService(IDiscountStrategy discountStrategy, ITaxCalculatorService taxCalculator)
        {
            this.discountStrategy = discountStrategy;
            this.taxCalculator = taxCalculator;
            orderItems = new List<IOrderItemModel>();
        }

        public IEnumerable<IOrderItemModel> OrderItems => orderItems;

        public void Add(IOrderItemModel orderItem)
        {
            orderItems.Add(orderItem);

        }

        public decimal CalculateTotalAmount()
        {
            decimal total = 0;

            foreach (var orderItem in OrderItems)
            {
                total += discountStrategy.ApplyDiscount(orderItem);
            }

            total = taxCalculator.ApplyTax(total);
            return total;
        }
    }
}