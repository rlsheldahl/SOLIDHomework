using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public class ShoppingCartModel
    {
        private readonly List<OrderItemModel> orderItems;

        public void Add(OrderItemModel orderItem)
        {

            orderItems.Add(orderItem);
        }
    }
}
