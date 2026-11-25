using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib.Models
{
    public class WarehouseWriteOffFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NomenclatureName { get; set; }
    }
}
