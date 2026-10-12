using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderRow
    {
        public string ContractNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CounterpartyName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PlannedShipmentDate { get; set; }

        // Список позиций
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Количество позиций (вычисляемое или из базы)
        public int PositionCount => Items.Count;

        // Итоговая сумма по заказу (сумма всех позиций)
        public decimal TotalAmount
        {
            get
            {
                decimal sum = 0;
                foreach (var item in Items)
                {
                    sum += item.TotalPrice;
                }
                return sum;
            }
        }
    }
}
