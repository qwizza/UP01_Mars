using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class WarehouseStockTests
    {
        // 1. Тестирование получения складских остатков (GetWarehouseStock)

        // Сценарий 1: Успешная загрузка остатков со склада
        [TestMethod]
        public void GetWarehouseStock_ValidData_ReturnsListAndEmptyError()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var expectedStock = new List<WarehouseItem>
            {
                new WarehouseItem { NomenclatureName = "Деталь А", StorageZone = "Склад 1", TotalQuantity = 500, ReservedQuantity = 100, UnitPrice = 2500.00m },
                new WarehouseItem { NomenclatureName = "Деталь Б", StorageZone = "Склад 2", TotalQuantity = 200, ReservedQuantity = 0, UnitPrice = 1200.00m }
            };

            string error = string.Empty;
            mockRepo.Setup(repo => repo.GetWarehouseStock(out error))
                    .Returns(expectedStock);

            IWarehouseRepository repository = mockRepo.Object;
            var result = repository.GetWarehouseStock(out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(400, result[0].AvailableQuantity);
        }

        // Сценарий 2: Запуск при пустом складе
        [TestMethod]
        public void GetWarehouseStock_EmptyWarehouse_ReturnsEmptyList()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            string error = string.Empty;

            mockRepo.Setup(repo => repo.GetWarehouseStock(out error))
                    .Returns(new List<WarehouseItem>());

            IWarehouseRepository repository = mockRepo.Object;
            var result = repository.GetWarehouseStock(out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.IsTrue(string.IsNullOrEmpty(error));
        }

        // Сценарий 3: Ошибка базы данных при запросе склада
        [TestMethod]
        public void GetWarehouseStock_DatabaseError_ReturnsEmptyListAndErrorMessage()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            string expectedError = "Ошибка базы данных: разрыв соединения с PostgreSQL";
            string error = string.Empty;

            mockRepo.Setup(repo => repo.GetWarehouseStock(out expectedError))
                    .Returns(new List<WarehouseItem>());

            IWarehouseRepository repository = mockRepo.Object;
            var result = repository.GetWarehouseStock(out error);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(expectedError, error);
        }

        // Сценарий 4: Агрегация общей стоимости всего склада
        [TestMethod]
        public void Warehouse_CalculateTotalWarehouseValue_ReturnsCorrectSum()
        {
            var stock = new List<WarehouseItem>
            {
                new WarehouseItem { TotalQuantity = 10, UnitPrice = 890.00m },
                new WarehouseItem { TotalQuantity = 2, UnitPrice = 1250.50m },
                new WarehouseItem { TotalQuantity = 1, UnitPrice = 3400.00m }
            };

            decimal totalSum = stock.Sum(x => x.TotalCost);

            Assert.AreEqual(14801.00m, totalSum);
        }

        // 2. Тестирование расчетов складской модели (WarehouseItem)

        // Сценарий 1: Вычисление свободного остатка (AvailableQuantity) при частичном резерве
        [TestMethod]
        public void WarehouseItem_AvailableQuantity_PartialReserve_CalculatesCorrectly()
        {
            var item = new WarehouseItem
            {
                TotalQuantity = 300,
                ReservedQuantity = 120
            };

            Assert.AreEqual(180, item.AvailableQuantity);
        }

        // Сценарий 2: Вычисление свободного остатка при полном резерве
        [TestMethod]
        public void WarehouseItem_AvailableQuantity_FullReserve_ReturnsZero()
        {
            var item = new WarehouseItem
            {
                TotalQuantity = 50,
                ReservedQuantity = 50
            };

            Assert.AreEqual(0, item.AvailableQuantity);
        }

        // Сценарий 3: Вычисление свободного остатка при отсутствии резерва
        [TestMethod]
        public void WarehouseItem_AvailableQuantity_ZeroReserve_EqualsTotalQuantity()
        {
            var item = new WarehouseItem
            {
                TotalQuantity = 75,
                ReservedQuantity = 0
            };

            Assert.AreEqual(75, item.AvailableQuantity);
        }

        // Сценарий 4: Вычисление общей стоимости остатка (TotalCost)
        [TestMethod]
        public void WarehouseItem_TotalCost_CalculatesCorrectProduct()
        {
            var item = new WarehouseItem
            {
                TotalQuantity = 100,
                UnitPrice = 1500.00m
            };

            Assert.AreEqual(150000.00m, item.TotalCost);
        }

        // Сценарий 5: Вычисление стоимости при нулевом остатке
        [TestMethod]
        public void WarehouseItem_TotalCost_ZeroQuantity_ReturnsZero()
        {
            var item = new WarehouseItem
            {
                TotalQuantity = 0,
                UnitPrice = 3400.00m
            };

            Assert.AreEqual(0.00m, item.TotalCost);
        }
    }
}
