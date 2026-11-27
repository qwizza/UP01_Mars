using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Validation;

namespace YPMarsLib
{
    public class WarehouseModel
    {
        private readonly IWarehouseRepository repository_;

        public List<WarehouseItem> Items { get; private set; } = new List<WarehouseItem>();

        public int PositionCount => Items?.Count ?? 0;
        public int TotalAvailableQuantity => CalculateTotalAvailableQuantity(Items);
        public decimal TotalStockCost => CalculateTotalStockCost(Items);

        public WarehouseModel(IWarehouseRepository repository)
        {
            repository_ = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<WarehouseItem> GetStock(out string error)
        {
            error = string.Empty;

            var stock = repository_.GetWarehouseStock(out error);
            if (!string.IsNullOrEmpty(error) || stock == null)
            {
                Items = new List<WarehouseItem>();
                return Items;
            }

            Items = stock;
            return Items;
        }

        public decimal CalculateTotalStockCost(IEnumerable<WarehouseItem> items)
        {
            if (items == null)
                return 0.00m;

            return items.Sum(item => item.TotalCost);
        }

        public int CalculateTotalAvailableQuantity(IEnumerable<WarehouseItem> items)
        {
            if (items == null)
                return 0;

            return items.Sum(item => item.AvailableQuantity);
        }
        public bool RegisterReceipt(WarehouseItem receiptItem, out string error)
        {
            if (!WarehouseValidate.ValidateReceipt(receiptItem, out error))
                return false;

            return repository_.RegisterStockReceipt(receiptItem, out error);
        }
    }
}
