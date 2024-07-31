using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public class ShoppingCart
    {
        public string Country { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public ShoppingCart(string country)
        {
            Country = country;
        }

        public void Add(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
