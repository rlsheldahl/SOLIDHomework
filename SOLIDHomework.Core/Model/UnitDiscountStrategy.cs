using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public class UnitDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(OrderItem orderItem)
        {
            decimal unitDiscount = 0;
            if (orderItem.SeasonEndDate <= DateTime.Now)
            {
                unitDiscount = 20;
            }
            return orderItem.Amount * orderItem.Price * (1 - unitDiscount / 100m);
        }
    }
}
