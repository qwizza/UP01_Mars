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

        List<OrderItem> GetOrderItemsByContract(string contractNumber, out string error);
        bool AddOrderItem(string contractNumber, OrderItem item, out string error);
        bool UpdateOrderItem(string contractNumber, OrderItem item, out string error);
        bool DeleteOrderItem(string contractNumber, OrderItem item, out string error);
        Dictionary<string, decimal> GetNomenclaturePrices(out string error);
    }
}
