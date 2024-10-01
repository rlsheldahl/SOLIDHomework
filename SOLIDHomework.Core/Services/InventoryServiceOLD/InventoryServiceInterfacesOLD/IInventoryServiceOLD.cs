using SOLIDHomework.Core.Services.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.InventoryService.InventoryServiceInterfaces
{
    public interface IInventoryServiceOLD
    {
        void ReserveInventory(ShoppingCartService cart);
    }
}
