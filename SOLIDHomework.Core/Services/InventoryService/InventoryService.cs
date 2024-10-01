using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services.InventoryService.InventoryServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        public void ReserveInventory(ShoppingCartService cart)
        {
            foreach (OrderItemModel item in cart.OrderItems)
            {
                try
                {
                    InventoryServiceOLD inventoryService = new InventoryServiceOLD();
                    inventoryService.ReserveInventory(cart);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Code, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }
}
