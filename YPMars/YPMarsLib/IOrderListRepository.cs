using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public interface IOrderListRepository
    {
        List<OrderRow> GetOrdersByPeriod(OrderDateFilter filter, out string error);
        List<OrderRow> GetAllOrders(out string error);
        string UpdateOrderStatus(string contractNumber, OrderStatus newStatus);
    }
}
