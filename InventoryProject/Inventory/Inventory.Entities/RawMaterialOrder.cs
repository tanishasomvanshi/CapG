using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class RawMaterialOrder
    {
        public int RawMaterialOrderID { get; set; }
        public List<RawMaterialOrderDetails> Order { get; set; }
    }
}
