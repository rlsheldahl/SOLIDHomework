using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public interface IOrderItemModelBuilder
    {
        IOrderItemModelBuilder WithAmount(int amount);
        IOrderItemModelBuilder WithSeassonEndDate(DateTime date);
        IOrderItemModelBuilder WithCode(string code);
        IOrderItemModelBuilder WithPrice(decimal price);
        IOrderItemModelBuilder WithType(string type);
        OrderItemModel Build();
    }
}
