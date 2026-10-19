using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderItem
    {
        public string NomenclatureName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Вычисляемая итоговая сумма по позиции
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
