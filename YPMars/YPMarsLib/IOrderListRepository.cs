using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public interface IOrderListRepository
    {
        List<Order> GetOrdersByPeriod(OrderDateFilter filter, out string error);
        List<Order> GetAllOrders(out string error);
        string UpdateOrderStatus(string contractNumber, OrderStatus newStatus);
    }
}
