using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public interface IWarehouseRepository
    {
        List<WarehouseItem> GetWarehouseStock(out string error);
    }
}
