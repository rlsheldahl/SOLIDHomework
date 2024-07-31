using SOLIDHomework.Core.Interfaces;
using SOLIDHomework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core
{
    //there are OCP and SOC violation
    //
    public class ShoppingCart
    {
        private readonly List<OrderItem> orderItems;
        private readonly IDiscountStrategy discountStrategy;
        private readonly ITaxCalculator taxCalculator;

        public ShoppingCart(IDiscountStrategy discountStrategy, ITaxCalculator taxCalculator)
        {
            this.discountStrategy = discountStrategy;
            this.taxCalculator = taxCalculator;
            orderItems = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> OrderItems => orderItems;

        public void Add(OrderItem orderItem)
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