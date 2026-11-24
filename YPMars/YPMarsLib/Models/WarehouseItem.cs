using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class WarehouseItem
    {
        [DisplayName("Наименование номенклатуры")]
        public string NomenclatureName { get; set; }

        [DisplayName("Зона хранения")]
        public string StorageZone { get; set; }

        [DisplayName("Общий остаток")]
        public int TotalQuantity { get; set; }

        [DisplayName("В резерве")]
        public int ReservedQuantity { get; set; }

        [DisplayName("Доступно")]
        public int AvailableQuantity => TotalQuantity - ReservedQuantity;

        [DisplayName("Цена за ед.")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Общая стоимость")]
        public decimal TotalCost => TotalQuantity * UnitPrice;
    }
}
