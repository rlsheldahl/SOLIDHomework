﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Interfaces
{
    public interface IInventoryService
    {
        void ReserveInventory(ShoppingCart cart);
    }
}
