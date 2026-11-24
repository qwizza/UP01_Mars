using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class WarehouseReceivingTests
    {
        // 1. Тестирование оформления поступления на склад (RegisterReceipt)

        // Сценарий 1: Успешное поступление позиции на склад
        [TestMethod]
        public void RegisterReceipt_ValidItem_ReturnsTrueAndEmptyError()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var receipt = new WarehouseItem
            {
                NomenclatureName = "Датчик давления МП-100",
                StorageZone = "Основной склад",
                TotalQuantity = 50,
                UnitPrice = 1250.50m
            };

            string repoError = string.Empty;
            mockRepo.Setup(repo => repo.RegisterStockReceipt(receipt, out repoError))
                    .Returns(true);

            var model = new WarehouseModel(mockRepo.Object);
            bool result = model.RegisterReceipt(receipt, out string error);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, error);
        }

        // Сценарий 2: Поступление с пустым наименованием номенклатуры
        [TestMethod]
        public void RegisterReceipt_EmptyNomenclatureName_ReturnsFalseAndValidationError()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var receipt = new WarehouseItem
            {
                NomenclatureName = "   ",
                TotalQuantity = 10,
                UnitPrice = 500.00m
            };

            var model = new WarehouseModel(mockRepo.Object);
            bool result = model.RegisterReceipt(receipt, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Необходимо указать наименование номенклатуры.", error);
        }

        // Сценарий 3: Поступление с нулевым или отрицательным количеством
        [TestMethod]
        public void RegisterReceipt_ZeroQuantity_ReturnsFalseAndValidationError()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var receipt = new WarehouseItem
            {
                NomenclatureName = "Датчик давления МП-100",
                TotalQuantity = 0,
                UnitPrice = 1250.50m
            };

            var model = new WarehouseModel(mockRepo.Object);
            bool result = model.RegisterReceipt(receipt, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Количество поступления должно быть больше нуля.", error);
        }

        // Сценарий 4: Поступление с отрицательной ценой за единицу
        [TestMethod]
        public void RegisterReceipt_NegativePrice_ReturnsFalseAndValidationError()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var receipt = new WarehouseItem
            {
                NomenclatureName = "Датчик давления МП-100",
                TotalQuantity = 15,
                UnitPrice = -100.00m
            };

            var model = new WarehouseModel(mockRepo.Object);
            bool result = model.RegisterReceipt(receipt, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Цена за единицу не может быть отрицательной.", error);
        }

        // Сценарий 5: Ошибка базы данных при оформлении поступления
        [TestMethod]
        public void RegisterReceipt_DatabaseError_ReturnsFalseAndErrorMessage()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var receipt = new WarehouseItem
            {
                NomenclatureName = "Блок питания БП-24В",
                TotalQuantity = 20,
                UnitPrice = 890.00m
            };

            string expectedError = "Ошибка базы данных: разрыв соединения с PostgreSQL";
            mockRepo.Setup(repo => repo.RegisterStockReceipt(receipt, out expectedError))
                    .Returns(false);

            var model = new WarehouseModel(mockRepo.Object);
            bool result = model.RegisterReceipt(receipt, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedError, error);
        }

        // 2. Тестирование пересчёта остатков и стоимости после поступления

        // Сценарий 1: Увеличение общего и доступного остатка при сохранении резерва
        [TestMethod]
        public void WarehouseItem_AfterReceipt_AvailableQuantityIncreasesAndReservePreserved()
        {
            var item = new WarehouseItem
            {
                NomenclatureName = "Датчик давления МП-100",
                TotalQuantity = 46,
                ReservedQuantity = 5,
                UnitPrice = 1250.50m
            };

            int receiptQuantity = 54;
            item.TotalQuantity += receiptQuantity;

            Assert.AreEqual(100, item.TotalQuantity);
            Assert.AreEqual(5, item.ReservedQuantity);
            Assert.AreEqual(95, item.AvailableQuantity);
        }

        // Сценарий 2: Пересчёт общей стоимости позиции (TotalCost) после поступления
        [TestMethod]
        public void WarehouseItem_AfterReceipt_TotalCostRecalculatesCorrectly()
        {
            var item = new WarehouseItem
            {
                NomenclatureName = "Блок питания БП-24В",
                TotalQuantity = 100,
                ReservedQuantity = 10,
                UnitPrice = 890.00m
            };

            item.TotalQuantity += 50;

            Assert.AreEqual(133500.00m, item.TotalCost);
        }

        // Сценарий 3: Пересчёт агрегированной стоимости всего склада после поступления
        [TestMethod]
        public void WarehouseModel_AfterReceipt_TotalStockCostRecalculates()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var updatedStock = new List<WarehouseItem>
            {
                new WarehouseItem { NomenclatureName = "Позиция 1", TotalQuantity = 100, ReservedQuantity = 10, UnitPrice = 1000.00m },
                new WarehouseItem { NomenclatureName = "Позиция 2", TotalQuantity = 50, ReservedQuantity = 0, UnitPrice = 500.00m }
            };

            string repoError = string.Empty;
            mockRepo.Setup(repo => repo.GetWarehouseStock(out repoError))
                    .Returns(updatedStock);

            var model = new WarehouseModel(mockRepo.Object);
            model.GetStock(out string error);

            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(125000.00m, model.TotalStockCost);
        }

        // Сценарий 4: Пересчёт общего доступного остатка склада после поступления
        [TestMethod]
        public void WarehouseModel_AfterReceipt_TotalAvailableQuantityRecalculates()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var updatedStock = new List<WarehouseItem>
            {
                new WarehouseItem { NomenclatureName = "Позиция 1", TotalQuantity = 100, ReservedQuantity = 10, UnitPrice = 1000.00m },
                new WarehouseItem { NomenclatureName = "Позиция 2", TotalQuantity = 50, ReservedQuantity = 5, UnitPrice = 500.00m }
            };

            string repoError = string.Empty;
            mockRepo.Setup(repo => repo.GetWarehouseStock(out repoError))
                    .Returns(updatedStock);

            var model = new WarehouseModel(mockRepo.Object);
            model.GetStock(out string error);

            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(135, model.TotalAvailableQuantity);
        }

        // Сценарий 5: Передача null вместо объекта поступления
        [TestMethod]
        public void RegisterReceipt_NullItem_ReturnsFalseWithoutException()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            var model = new WarehouseModel(mockRepo.Object);

            bool result = model.RegisterReceipt(null, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Данные поступления не переданы.", error);
        }
    }
}
