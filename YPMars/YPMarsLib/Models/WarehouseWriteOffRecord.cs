    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib.Models
{
    public class WarehouseWriteOffRecord
    {
        [Browsable(false)]
        public int WriteOffId { get; set; }

        [DisplayName("Дата списания")]
        public DateTime WriteOffDate { get; set; }

        [DisplayName("Наименование")]
        public string NomenclatureName { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Цена за ед.")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Сумма")]
        public decimal TotalPrice => Quantity * UnitPrice;

        [DisplayName("Пользователь")]
        public string UserName { get; set; }
    }
}
