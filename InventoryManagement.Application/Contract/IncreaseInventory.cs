﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract
{
    public class IncreaseInventory
    {
        public long InventoryID { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }

    }
}
