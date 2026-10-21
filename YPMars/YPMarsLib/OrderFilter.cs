using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderFilter
    {
        public string CounterpartyName { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public DateTime? PlannedShipmentFrom { get; set; }
        public DateTime? PlannedShipmentTo { get; set; }
    }
}
