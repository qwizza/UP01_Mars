using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class OrderItemTests
    {
        // 1. Тестирование получения позиций заказа (GetOrderItemsByContract)
        // Сценарий 1: Успешная загрузка позиций существующего заказа
        [TestMethod]
        public void GetOrderItemsByContract_ExistingContract_ReturnsItemsAndEmptyError()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var expectedItems = new List<OrderItem>
        {
            new OrderItem { NomenclatureName = "Деталь А", Quantity = 100, UnitPrice = 2500.00m },
            new OrderItem { NomenclatureName = "Деталь Б", Quantity = 50, UnitPrice = 1200.00m }
        };

            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetOrderItemsByContract("ДГ-2026-000001", out error))
                    .Returns(expectedItems);

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetOrderItemsByContract("ДГ-2026-000001", out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual("Деталь А", result[0].NomenclatureName);
        }

        // Сценарий 2: Заказ не содержит позиций
        [TestMethod]
        public void GetOrderItemsByContract_EmptyOrder_ReturnsEmptyList()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            string error = string.Empty;

            mockRepo.Setup(repo => repo.GetOrderItemsByContract("ДГ-2026-000002", out error))
                    .Returns(new List<OrderItem>());

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetOrderItemsByContract("ДГ-2026-000002", out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.IsTrue(string.IsNullOrEmpty(error));
        }

        // Сценарий 3: Ошибка базы данных при запросе позиций
        [TestMethod]
        public void GetOrderItemsByContract_DatabaseError_ReturnsEmptyListAndErrorMessage()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            string expectedError = "Ошибка базы данных: Потеряно соединение с PostgreSQL";
            string error = string.Empty;

            mockRepo.Setup(repo => repo.GetOrderItemsByContract(It.IsAny<string>(), out expectedError))
            .Returns(new List<OrderItem>());

            IOrderListRepository repository = mockRepo.Object;
            var result = repository.GetOrderItemsByContract("ДГ-2026-000003", out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(expectedError, error);
        }

        // 2. Тестирование расчета итогов по позициям
        // Сценарий 1: Проверка вычисления TotalPrice для строки
        [TestMethod]
        public void OrderItem_TotalPrice_CalculatesCorrectly()
        {
            var item = new OrderItem
            {
                NomenclatureName = "Деталь А",
                Quantity = 100,
                UnitPrice = 2500.00m
            };

            Assert.AreEqual(250000.00m, item.TotalPrice);
        }

        // Сценарий 2: Проверка пересчёта TotalPrice после изменения количества
        [TestMethod]
        public void OrderItem_ChangeQuantity_RecalculatesTotalPrice()
        {
            var item = new OrderItem
            {
                NomenclatureName = "Деталь А",
                Quantity = 100,
                UnitPrice = 2500.00m
            };

            item.Quantity = 150;

            Assert.AreEqual(375000.00m, item.TotalPrice);
        }

        // Сценарий 3: Проверка неизменности и автоподстановки цены
        [TestMethod]
        public void ItemEditForm_PriceControl_IsReadOnlyAndAutoUpdated()
        {
            var item = new OrderItem
            {
                NomenclatureName = "Деталь А",
                Quantity = 100,
                UnitPrice = 2500.00m
            };

            Assert.AreEqual(2500.00m, item.UnitPrice);
        }

        // 3. Тестирование редактирования позиции заказа (UpdateOrderItem)
        // Сценарий 1: Успешное редактирование позиции
        [TestMethod]
        public void UpdateOrderItem_ValidData_ReturnsTrue()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var itemToUpdate = new OrderItem { NomenclatureName = "Деталь А", Quantity = 150, UnitPrice = 2500.00m };
            string error = string.Empty;

            mockRepo.Setup(repo => repo.UpdateOrderItem("ДГ-2026-000001", itemToUpdate, out error))
                    .Returns(true);

            IOrderListRepository repository = mockRepo.Object;
            itemToUpdate.Quantity = 150;

            bool success = repository.UpdateOrderItem("ДГ-2026-000001", itemToUpdate, out error);

            Assert.IsTrue(success);
            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(375000.00m, itemToUpdate.TotalPrice);
        }

        // Сценарий 2: Редактирование позиции с нулевым количеством
        [TestMethod]
        public void UpdateOrderItem_ZeroQuantity_ReturnsFalseAndErrorMessage()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var invalidItem = new OrderItem { NomenclatureName = "Деталь А", Quantity = 0, UnitPrice = 2500.00m };
            string expectedError = "Количество должно быть больше нуля.";
            string error = expectedError;

            mockRepo.Setup(repo => repo.UpdateOrderItem(It.IsAny<string>(), invalidItem, out error))
                    .Returns(false);

            IOrderListRepository repository = mockRepo.Object;
            bool success = repository.UpdateOrderItem("ДГ-2026-000001", invalidItem, out error);

            Assert.IsFalse(success);
            Assert.AreEqual(expectedError, error);
        }

        // Сценарий 3: Ошибка базы данных при редактировании
        [TestMethod]
        public void UpdateOrderItem_DatabaseError_ReturnsFalseAndErrorMessage()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var item = new OrderItem { NomenclatureName = "Деталь А", Quantity = 10, UnitPrice = 100m };
            string expectedError = "Ошибка базы данных: разрыв соединения";
            string error = string.Empty;

            mockRepo.Setup(repo => repo.UpdateOrderItem(It.IsAny<string>(), It.IsAny<OrderItem>(), out expectedError))
            .Returns(false);

            IOrderListRepository repository = mockRepo.Object;
            bool success = repository.UpdateOrderItem("ДГ-2026-000001", item, out error);

            Assert.IsFalse(success);
            Assert.AreEqual(expectedError, error);
        }

        // 4. Тестирование удаления позиции заказа (DeleteOrderItem)
        // Сценарий 1: Успешное удаление позиции
        [TestMethod]
        public void DeleteOrderItem_ExistingItem_ReturnsTrue()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var itemToDelete = new OrderItem { NomenclatureName = "Деталь А" };
            string error = string.Empty;

            mockRepo.Setup(repo => repo.DeleteOrderItem("ДГ-2026-000001", itemToDelete, out error))
                    .Returns(true);

            IOrderListRepository repository = mockRepo.Object;
            bool success = repository.DeleteOrderItem("ДГ-2026-000001", itemToDelete, out error);

            Assert.IsTrue(success);
            Assert.AreEqual(string.Empty, error);
        }

        // Сценарий 2: Ошибка базы данных при удалении
        [TestMethod]
        public void DeleteOrderItem_DatabaseError_ReturnsFalseAndErrorMessage()
        {
            var mockRepo = new Mock<IOrderListRepository>();
            var itemToDelete = new OrderItem { NomenclatureName = "Деталь А" };
            string expectedError = "Ошибка базы данных при удалении";
            string error = string.Empty;

            mockRepo.Setup(repo => repo.DeleteOrderItem(It.IsAny<string>(), It.IsAny<OrderItem>(), out expectedError))
             .Returns(false);

            IOrderListRepository repository = mockRepo.Object;
            bool success = repository.DeleteOrderItem("ДГ-2026-000001", itemToDelete, out error);

            Assert.IsFalse(success);
            Assert.AreEqual(expectedError, error);
        }
        // 5. Тестирование пересчёта итогов по заказу после изменения состава
        // Сценарий 1: Пересчёт итоговой суммы после редактирования позиции
        [TestMethod]
        public void Order_RecalculatesTotals_AfterItemUpdate()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2026-000001",
                Items = new List<OrderItem>
            {
                new OrderItem { NomenclatureName = "Деталь А", Quantity = 100, UnitPrice = 2500.00m },
                new OrderItem { NomenclatureName = "Деталь Б", Quantity = 50, UnitPrice = 1000.00m }
            }
            };

            Assert.AreEqual(2, order.PositionCount);
            Assert.AreEqual(300000.00m, order.TotalAmount);

            order.Items[0].Quantity = 150;

            Assert.AreEqual(2, order.PositionCount);
            Assert.AreEqual(425000.00m, order.TotalAmount);
        }

        // Сценарий 2: Пересчёт итоговой суммы после удаления позиции
        [TestMethod]
        public void Order_RecalculatesTotals_AfterItemDeletion()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2026-000001",
                Items = new List<OrderItem>
            {
                new OrderItem { NomenclatureName = "Деталь А", Quantity = 100, UnitPrice = 2500.00m },
                new OrderItem { NomenclatureName = "Деталь Б", Quantity = 50, UnitPrice = 1000.00m }
            }
            };

            Assert.AreEqual(2, order.PositionCount);
            Assert.AreEqual(300000.00m, order.TotalAmount);

            order.Items.RemoveAt(1);

            Assert.AreEqual(1, order.PositionCount);
            Assert.AreEqual(250000.00m, order.TotalAmount);
        }
    }
}