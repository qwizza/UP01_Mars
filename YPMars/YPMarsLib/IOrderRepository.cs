using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public interface IOrderRepository
    {
        string CreateOrder(Order order);
        int GetLastOrderNumberInYear(int year);
        List<Order> GetAllOrders();
    }
}
