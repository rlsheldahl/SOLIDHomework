using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{
    public class InventoryService
    {
        // that is Database-based service 
        public void ReserveInventory(ShoppingCart cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    InventoryService inventoryService = new InventoryService();
                    inventoryService.Reserve(item.Code, item.Amount);

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
        public void Reserve(string itemCode, int amount) 
        { 
        }
    }
}