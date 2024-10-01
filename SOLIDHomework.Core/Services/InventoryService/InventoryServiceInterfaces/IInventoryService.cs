using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Services.InventoryService.InventoryServiceInterfaces
{
    public interface IInventoryService
    {
        void ReserveInventory(ShoppingCartService cart);
    }
}
