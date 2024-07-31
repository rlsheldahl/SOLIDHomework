using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(OrderItem orderItem);
    }
}
