using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;
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
        public bool ValidateWriteOff(WarehouseItem writeOffItem, out string error)
        {
            if (!WarehouseValidate.ValidateWriteOff(writeOffItem, out error))
                return false;

            if (writeOffItem.TotalQuantity > writeOffItem.AvailableQuantity)
            {
                error = $"Недостаточно доступного остатка для списания. Доступно: {writeOffItem.AvailableQuantity} шт.";
                return false;
            }
            return true;
        }

        public bool RegisterWriteOff(WarehouseItem writeOffItem, string userName, out string error)
        {
            if (!ValidateWriteOff(writeOffItem, out error))
                return false;

            return repository_.RegisterStockWriteOff(writeOffItem, userName, out error);
        }

        public List<WarehouseWriteOffRecord> GetWriteOffReport(WarehouseWriteOffFilter filter, out string error)
        {
            return repository_.GetWriteOffReport(filter, out error);
        }
    }
}
