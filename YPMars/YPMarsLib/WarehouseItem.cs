using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class WarehouseItem
    {
        public string NomenclatureName { get; set; }
        public string StorageZone { get; set; }
        public int TotalQuantity { get; set; }
        public int ReservedQuantity { get; set; }

        public int AvailableQuantity => TotalQuantity - ReservedQuantity;

        public decimal UnitPrice { get; set; }

        public decimal TotalCost => TotalQuantity * UnitPrice;
    }
}
