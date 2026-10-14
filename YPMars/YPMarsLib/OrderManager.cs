using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderManager
    {
        private readonly IOrderListRepository _repository;
        private readonly List<OrderRow> _currentOrders = new List<OrderRow>();

        public OrderManager(IOrderListRepository repository)
        {
            _repository = repository;
        }

        public List<OrderRow> GetOrders(OrderDateFilter filterDate, out string error)
        {
            var orders = _repository.GetOrdersByPeriod(filterDate, out error);
            if (string.IsNullOrEmpty(error))
            {
                _currentOrders.Clear();
                _currentOrders.AddRange(orders);
            }
            return orders;
        }

        public string UpdateStatus(string contractNumber, OrderStatus newStatus)
        {
            return _repository.UpdateOrderStatus(contractNumber, newStatus);
        }

        public int GetTotalCount()
        {
            return _currentOrders.Count;
        }

        public decimal GetTotalSum()
        {
            decimal sum = 0;
            foreach (var ord in _currentOrders)
            {
                sum += ord.TotalAmount;
            }
            return sum;
        }

        public decimal CalculateTotalSum(List<OrderRow> orders)
        {
            decimal sum = 0;
            foreach (var ord in orders)
            {
                sum += ord.TotalAmount;
            }
            return sum;
        }
    }
}
