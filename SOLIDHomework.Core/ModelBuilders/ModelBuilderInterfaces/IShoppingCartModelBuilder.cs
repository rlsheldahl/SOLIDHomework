using SOLIDHomework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces
{
    public interface IShoppingCartModelBuilder
    {
        IShoppingCartModelBuilder AddItem(IOrderItemModel item);
        ShoppingCartModel Build();
    }
}
