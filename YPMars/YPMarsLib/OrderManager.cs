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
        private readonly List<Order> _currentOrders = new List<Order>();

        public OrderManager(IOrderListRepository repository)
        {
            _repository = repository;
        }

        public List<Order> GetOrders(OrderDateFilter filterDate, out string error)
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

        public decimal CalculateTotalSum(List<Order> orders)
        {
            decimal sum = 0;
            foreach (var ord in orders)
            {
                sum += ord.TotalAmount;
            }
            return sum;
        }

        public List<OrderItem> GetOrderItems(string contractNumber, out string error)
        {
            return _repository.GetOrderItemsByContract(contractNumber, out error);
        }

        public bool AddItemToOrder(string contractNumber, OrderItem item, out string error)
        {
            return _repository.AddOrderItem(contractNumber, item, out error);
        }

        public bool UpdateItemInOrder(string contractNumber, OrderItem item, out string error)
        {
            return _repository.UpdateOrderItem(contractNumber, item, out error);
        }

        public bool DeleteItemFromOrder(string contractNumber, OrderItem item, out string error)
        {
            return _repository.DeleteOrderItem(contractNumber, item, out error);
        }
    }
}
