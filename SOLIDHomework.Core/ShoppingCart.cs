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
        private readonly string country;
        private readonly List<OrderItem> orderItems;
        private readonly IDiscountStrategy discountStrategy;

        public ShoppingCart(string country, IDiscountStrategy discountStrategy)
        //public ShoppingCart(string country)
        {
            this.country = country;
            this.discountStrategy = discountStrategy;
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
            if (country == "US")
            {
                total *= 1.2M;
            }
            else
            {
                total *= 1.1M;
            }
            return total;
        }
    }
}