using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public class WeightStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(IOrderItemModel orderItem)
        {
            return orderItem.Amount * orderItem.Price / 1000m;
        }
    }
}
