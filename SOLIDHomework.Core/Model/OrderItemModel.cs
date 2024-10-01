using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core
{
    public class OrderItemModel : IOrderItemModel
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime SeasonEndDate { get; set; }

        public decimal CalculateTotal()
        {
            return Amount * Price;
        }
    }
}