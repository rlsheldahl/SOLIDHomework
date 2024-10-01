using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public class OrderItemModelBuilder : IOrderItemModelBuilder
    {
        private OrderItemModel _model;
        public OrderItemModelBuilder()
        {
            _model = new OrderItemModel();
        }

        public IOrderItemModelBuilder WithAmount(int amount)
        {
            _model.Amount = amount;
            return this;
        }

        public IOrderItemModelBuilder WithSeassonEndDate(DateTime date)
        {
            _model.SeasonEndDate = date;
            return this;
        }

        public IOrderItemModelBuilder WithCode(string code)
        {
            _model.Code = code;
            return this;
        }

        public IOrderItemModelBuilder WithPrice(decimal price)
        {
            _model.Price = price;
            return this;
        }

        public IOrderItemModelBuilder WithType(string type)
        {
            _model.Type = type;
            return this;
        }

        public OrderItemModel Build()
        {
            return _model;
        }
    }
}
