using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;

namespace YPMarsLib.Interfaces
{
    public interface IOrderReportRepository
    {
        OrderReport GetOrderReportData(string contractNumber, out string error);
    }
}
