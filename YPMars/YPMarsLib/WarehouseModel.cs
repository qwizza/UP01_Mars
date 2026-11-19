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

            var item = repository_.GetWarehouseStock(out string repoError);
            if (!string.IsNullOrEmpty(repoError))
            {
                error = repoError;
                return new List<WarehouseItem>();
            }

            return repository_.GetWarehouseStock(out error);
        }

        public decimal CalculateTotalStockCost(IEnumerable<WarehouseItem> items)
        {
            if (items == null) 
            {
                return 0.00m;
            }

            return items.Sum(item => item.TotalCost);
        }

        public decimal CalculateTotalAvailableQuantity(IEnumerable<WarehouseItem> items)
        {
            if (items == null)
            {
                return 0.00m;
            }

            return items.Sum(item => item.AvailableQuantity);
        }
    }
}
