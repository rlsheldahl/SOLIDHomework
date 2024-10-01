using SOLIDHomework.Core.Interfaces;
using SOLIDHomework.Core.InventoryService.InventoryServiceInterfaces;
using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{ 
    public class InventoryServiceOLD : IInventoryServiceOLD
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