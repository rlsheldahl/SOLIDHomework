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
        private readonly List<OrderItemModel> orderItems;
        private readonly IDiscountStrategy discountStrategy;
        private readonly ITaxCalculator taxCalculator;

        public ShoppingCart(IDiscountStrategy discountStrategy, ITaxCalculator taxCalculator)
        {
            this.discountStrategy = discountStrategy;
            this.taxCalculator = taxCalculator;
            orderItems = new List<OrderItemModel>();
        }

        public IEnumerable<OrderItemModel> OrderItems => orderItems;

        public void Add(OrderItemModel orderItem)
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