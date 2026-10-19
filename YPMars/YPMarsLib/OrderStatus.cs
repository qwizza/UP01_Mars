using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public enum OrderStatus
    {
        New,
        InProgress,
        ReadyForShipment,
        Shipment,
        Completed,
        Cancelled
    }
}
