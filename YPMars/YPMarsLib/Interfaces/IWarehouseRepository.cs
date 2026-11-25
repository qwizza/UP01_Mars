using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;

namespace YPMarsLib
{
    public interface IWarehouseRepository
    {
        List<WarehouseItem> GetWarehouseStock(out string error);
        bool RegisterStockReceipt(WarehouseItem receiptItem, out string error);
        bool RegisterStockWriteOff(WarehouseItem writeOffItem, string userName, out string error);
        List<WarehouseWriteOffRecord> GetWriteOffReport(WarehouseWriteOffFilter filter, out string error);
    }
}
