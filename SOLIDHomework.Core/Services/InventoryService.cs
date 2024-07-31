using SOLIDHomework.Core.Interfaces;
using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{
    public class InventoryService : IInventoryService
    {

        public void ReserveInventory(ShoppingCart cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    InventoryService inventoryService = new InventoryService();
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