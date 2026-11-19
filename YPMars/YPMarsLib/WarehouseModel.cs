using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class WarehouseModel
    {
        private readonly IWarehouseRepository repository_;

        public WarehouseModel(IWarehouseRepository repository)
        {
            repository_ = repository;
        }

        public List<WarehouseItem> GetStock(out string error)
        {
            error = string.Empty;

            var stock = repository_.GetWarehouseStock(out error);
            if (!string.IsNullOrEmpty(error))
            {
                return new List<WarehouseItem>();
            }
            return stock;
        }

        public decimal CalculateTotalStockCost(IEnumerable<WarehouseItem> items)
        {
            if (items == null) 
            {
                return 0.00m;
            }

            return items.Sum(item => item.TotalCost);
        }

        public int CalculateTotalAvailableQuantity(IEnumerable<WarehouseItem> items)
        {
            if (items == null) return 0;
            return items.Sum(item => item.AvailableQuantity);
        }
    }
}
