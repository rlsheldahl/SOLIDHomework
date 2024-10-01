using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public class SpecialDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(IOrderItemModel orderItem)
        {
            decimal total = orderItem.Amount * orderItem.Price;
            decimal setsOfFour = orderItem.Amount / 4;
            return total - setsOfFour * orderItem.Price; // Discount on groups of 4 items
        }
    }
}
