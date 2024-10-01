using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Services.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.ModelBuilders
{
    public class ShoppingCartModelBuilder : IShoppingCartModelBuilder
    {
        private ShoppingCartService _model;
        private SpecialDiscountStrategy _specialDiscountStrategy;
        private UnitDiscountStrategy _unitDiscountStrategy;
        private WeightStrategy _weightStrategy;
        private USTaxCalculator _UStaxCalculator;
        private OtherCountryTaxCalculator _otherCountryTaxCalculator;
            
        public ShoppingCartModelBuilder(string country)
        {
            if (country == "US")
            {
                _model = new ShoppingCartService(_specialDiscountStrategy, _UStaxCalculator);
            }
            else
            {
                _model = new ShoppingCartService(_specialDiscountStrategy, _otherCountryTaxCalculator);
            }
        }

        public IShoppingCartModelBuilder AddItem(IOrderItemModel item)
        {
            _model.Add(item);
            return this;
        }

        public ShoppingCartModel Build()
        {
            return _model;
        }
    }
}
