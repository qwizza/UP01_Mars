using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderItem
    {
        [DisplayName("Наименование")]
        public string NomenclatureName { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
        [DisplayName("Цена за ед.")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Сумма")]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
