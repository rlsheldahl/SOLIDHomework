using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public class OrderItemBuilder
    {
        private OrderItem _orderItem;

        public OrderItemBuilder()
        {
            _orderItem = new OrderItem();
        }

        public OrderItemBuilder WithAmount(int amount)
        {
            _orderItem.Amount = amount;
            return this;
        }

        public OrderItemBuilder WithSeassonEndDate(DateTime date)
        {
            _orderItem.SeasonEndDate = date;
            return this;
        }

        public OrderItemBuilder WithCode(string code)
        {
            _orderItem.Code = code;
            return this;
        }

        public OrderItemBuilder WithPrice(decimal price)
        {
            _orderItem.Price = price;
            return this;
        }

        public OrderItemBuilder WithType(string type)
        {
            _orderItem.Type = type;
            return this;
        }

        public OrderItem Build()
        {
            return _orderItem;
        }
    }
}
