using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public interface IOrderItemModel
    {
        string Type { get; }
        decimal Amount { get; }
        decimal Price { get; }
        DateTime SeasonEndDate { get; }
        decimal CalculateTotal();
    }
}
