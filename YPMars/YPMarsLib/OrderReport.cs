using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderReport
    {
        public string ContractNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? PlannedShipmentDate { get; set; }
        public string StatusText { get; set; }
        public string CounterpartyName { get; set; }
        public string CounterpartyINN { get; set; }
        public string CounterpartyKPP { get; set; }
        public string CounterpartyAddress { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime GeneratedDate { get; set; }
        public string ResponsibleEmployee { get; set; }

        public int PositionCount => Items?.Count ?? 0;
        public decimal TotalAmount => Items?.Sum(i => i.TotalPrice) ?? 0m;
    }
}
