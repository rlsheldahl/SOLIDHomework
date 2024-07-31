using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Builder
{
    public class ShoppingCartBuilder
    {
        private ShoppingCart _shoppingCart;
        private SpecialDiscountStrategy _specialDiscountStrategy;
        private UnitDiscountStrategy _unitDiscountStrategy;
        private WeightStrategy _weightStrategy;
        private USTaxCalculator _UStaxCalculator;
        private OtherCountryTaxCalculator _otherCountryTaxCalculator;

        public ShoppingCartBuilder(string country)
        {
            if (country == "US")
            {
                _shoppingCart = new ShoppingCart(_specialDiscountStrategy, _UStaxCalculator);
            }
            else
            {
                _shoppingCart = new ShoppingCart(_specialDiscountStrategy, _otherCountryTaxCalculator);
            }
        }

        public ShoppingCartBuilder AddItem(OrderItem item)
        {
            _shoppingCart.Add(item);
            return this;
        }

        public ShoppingCart Build()
        {
            return _shoppingCart;
        }

    }
}
