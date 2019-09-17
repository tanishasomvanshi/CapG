﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Exception
{
    public class InventoryException : ApplicationException
    {
        public InventoryException()
            : base()
        {
        }

        public InventoryException(string message)
            : base(message)
        {
        }
    }
}
