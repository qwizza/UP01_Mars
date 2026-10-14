using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class OrderListTests
    {
        // 1. Тестирование метода получения списка заказов (GetOrdersByPeriod и GetAllOrders)
        // Сценарий 1: Загрузка заказов по умолчанию (фильтр за последние 30 дней)
        [TestMethod]
        public void GetOrdersByPeriod_Default30DaysFilter_ReturnsFilteredOrders()
        {
            var filter = new OrderDateFilter
            {
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now
            };

            var mockRepo = new Mock<IOrderListRepository>();
            var expectedOrders = new List<Order>
            {
                new Order { ContractNumber = "ДГ-001", OrderDate = DateTime.Now.AddDays(-5) },
                new Order { ContractNumber = "ДГ-002", OrderDate = DateTime.Now.AddDays(-15) }
            };

            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetOrdersByPeriod(It.IsAny<OrderDateFilter>(), out error))
                    .Returns(expectedOrders);

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetOrdersByPeriod(filter, out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("ДГ-001", result[0].ContractNumber);
            Assert.AreEqual("ДГ-002", result[1].ContractNumber);
        }

        // Сценарий 2: Выборка всех заказов без ограничений (GetAllOrders)
        [TestMethod]
        public void GetAllOrders_ReturnsAllOrdersWithCalculatedProperties()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var allOrders = new List<Order>
            {
                new Order
                {
                    ContractNumber = "ДГ-001",
                    Items = new List<OrderItem> { new OrderItem { Quantity = 10, UnitPrice = 100 } }
                },
                new Order
                {
                    ContractNumber = "ДГ-002",
                    Items = new List<OrderItem> { new OrderItem { Quantity = 5, UnitPrice = 200 } }
                },
                new Order
                {
                    ContractNumber = "ДГ-003",
                    Items = new List<OrderItem>()
                }
            };

            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetAllOrders(out error))
                    .Returns(allOrders);

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetAllOrders(out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].PositionCount);
            Assert.AreEqual(1000m, result[0].TotalAmount);
            Assert.AreEqual(0, result[2].PositionCount);
            Assert.AreEqual(0m, result[2].TotalAmount);
        }

        // Сценарий 3: Заказы за указанный период отсутствуют
        [TestMethod]
        public void GetOrdersByPeriod_NoOrdersInPeriod_ReturnsEmptyList()
        {
            var filter = new OrderDateFilter
            {
                StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2010, 1, 31)
            };

            var mockRepo = new Mock<IOrderListRepository>();
            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetOrdersByPeriod(It.IsAny<OrderDateFilter>(), out error))
                    .Returns(new List<Order>());

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetOrdersByPeriod(filter, out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.IsTrue(string.IsNullOrEmpty(error));
        }

        // 2. Тестирование агрегации суммы и позиций в Order / OrderManager
        // Сценарий 1: Заказ с двумя позициями (проверка вычисляемых свойств)
        [TestMethod]
        public void Order_TwoItems_CalculatesPositionCountAndTotalAmountCorrectly()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2024-001",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Позиция А", Quantity = 100, UnitPrice = 2500.00m },
                    new OrderItem { NomenclatureName = "Позиция Б", Quantity = 50, UnitPrice = 1800.00m }
                }
            };
            Assert.AreEqual(2, order.PositionCount);
            Assert.AreEqual(2, order.Items.Count);
            Assert.AreEqual("Позиция А", order.Items[0].NomenclatureName);
            Assert.AreEqual("Позиция Б", order.Items[1].NomenclatureName);
            Assert.AreEqual(340000.00m, order.TotalAmount);
        }

        // Сценарий 2: Заказ без позиций
        [TestMethod]
        public void OrderRow_EmptyItems_ReturnsZeroValues()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2024-002",
                Items = new List<OrderItem>()
            };
            Assert.AreEqual(0, order.PositionCount);
            Assert.IsNotNull(order.Items);
            Assert.AreEqual(0, order.Items.Count);
            Assert.AreEqual(0.00m, order.TotalAmount);
        }

        // Сценарий 3: Подсчёт общих итогов по всем выведенным заказам через OrderManager
        [TestMethod]
        public void OrderManager_CalculateTotals_ReturnsCorrectAggregates()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem> { new OrderItem { Quantity = 1, UnitPrice = 340000.00m } }
                },
                new Order
                {
                    Items = new List<OrderItem> { new OrderItem { Quantity = 1, UnitPrice = 100000.00m } }
                }
            };
            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetOrdersByPeriod(It.IsAny<OrderDateFilter>(), out error))
                    .Returns(orders);
            var manager = new OrderManager(mockRepo.Object);
            var loadedOrders = manager.GetOrders(new OrderDateFilter(), out error);
            int totalCount = manager.GetTotalCount();
            decimal totalSum = manager.GetTotalSum();
            Assert.AreEqual(2, totalCount);
            Assert.AreEqual(440000.00m, totalSum);
        }
    }
}
}
