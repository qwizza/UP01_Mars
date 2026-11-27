using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib;
using YPMarsLib.Models;
using YPMarsLib.Services;

namespace YPMarsTests
{
    [TestClass]
    public class WarehouseWriteOffTests
    {
        // ==========================================
        // 1. Тестирование списания (WarehouseModel)
        // ==========================================

        [TestMethod]
        public void RegisterWriteOff_ValidData_ReturnsTrue()
        {
            var mockRepo = new Mock<IWarehouseRepository>();
            string error = string.Empty;

            mockRepo.Setup(r => r.RegisterStockWriteOff(It.IsAny<WarehouseItem>(), It.IsAny<string>(), out error))
                    .Returns(true);

            var model = new WarehouseModel(mockRepo.Object);
            var item = new WarehouseItem
            {
                NomenclatureName = "Деталь А",
                TotalQuantity = 10,
                ReservedQuantity = 0,
                UnitPrice = 2500.00m
            };

            bool result = model.RegisterWriteOff(item, "petrov_a", out error);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, error);
            mockRepo.Verify(r => r.RegisterStockWriteOff(It.IsAny<WarehouseItem>(), "petrov_a", out error), Times.Once);
        }

        [TestMethod]
        public void RegisterWriteOff_EmptyName_ReturnsFalse()
        {
            var mockRepo = new Mock<IWarehouseRepository>(MockBehavior.Strict);
            var model = new WarehouseModel(mockRepo.Object);

            var item = new WarehouseItem { NomenclatureName = " ", TotalQuantity = 10, UnitPrice = 100m };

            bool result = model.RegisterWriteOff(item, "petrov_a", out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Необходимо указать наименование номенклатуры.", error);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public void RegisterWriteOff_NonPositiveQuantity_ReturnsFalse(int qty)
        {
            var mockRepo = new Mock<IWarehouseRepository>(MockBehavior.Strict);
            var model = new WarehouseModel(mockRepo.Object);

            var item = new WarehouseItem { NomenclatureName = "Деталь А", TotalQuantity = qty, UnitPrice = 100m };

            bool result = model.RegisterWriteOff(item, "petrov_a", out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Количество списания должно быть больше нуля.", error);
        }

        [TestMethod]
        public void RegisterWriteOff_NegativePrice_ReturnsFalse()
        {
            var mockRepo = new Mock<IWarehouseRepository>(MockBehavior.Strict);
            var model = new WarehouseModel(mockRepo.Object);

            var item = new WarehouseItem { NomenclatureName = "Деталь А", TotalQuantity = 10, UnitPrice = -100.00m };

            bool result = model.RegisterWriteOff(item, "petrov_a", out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Цена за единицу не может быть отрицательной.", error);
        }

        [TestMethod]
        public void RegisterWriteOff_DatabaseError_ReturnsFalseAndError()
        {
            string repoError = "Ошибка базы данных при оформлении списания: разрыв соединения";
            var mockRepo = new Mock<IWarehouseRepository>();
            string capturedError = repoError;

            mockRepo.Setup(r => r.RegisterStockWriteOff(It.IsAny<WarehouseItem>(), It.IsAny<string>(), out capturedError))
                    .Returns(false);

            var model = new WarehouseModel(mockRepo.Object);
            var item = new WarehouseItem { NomenclatureName = "Деталь А", TotalQuantity = 1, UnitPrice = 100m };

            bool result = model.RegisterWriteOff(item, "petrov_a", out string error);

            Assert.IsFalse(result);
            Assert.AreEqual(repoError, error);
        }

        [TestMethod]
        public void RegisterWriteOff_NullItem_ReturnsFalse()
        {
            var mockRepo = new Mock<IWarehouseRepository>(MockBehavior.Strict);
            var model = new WarehouseModel(mockRepo.Object);

            bool result = model.RegisterWriteOff(null, "petrov_a", out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Данные списания не переданы.", error);
        }

        // ==========================================
        // 2. Тестирование пересчёта остатков (WarehouseItem)
        // ==========================================

        [TestMethod]
        public void WarehouseItem_AfterWriteOff_PreservesReserveAndUpdatesAvailable()
        {
            var item = new WarehouseItem { TotalQuantity = 100, ReservedQuantity = 30, UnitPrice = 100m };

            item.TotalQuantity -= 50; // имитация списания

            Assert.AreEqual(50, item.TotalQuantity);
            Assert.AreEqual(30, item.ReservedQuantity);
            Assert.AreEqual(20, item.AvailableQuantity);
        }

        [TestMethod]
        public void WarehouseItem_TotalCost_AfterWriteOff()
        {
            var item = new WarehouseItem { TotalQuantity = 50, ReservedQuantity = 0, UnitPrice = 2000.00m };

            Assert.AreEqual(100000.00m, item.TotalCost);
        }

        [TestMethod]
        public void WarehouseItem_NegativeAvailableQuantity_ReturnsZero()
        {
            // Если резерв больше остатка, AvailableQuantity должно быть 0, а не отрицательным
            var item = new WarehouseItem { TotalQuantity = 10, ReservedQuantity = 15 };

            Assert.AreEqual(0, item.AvailableQuantity);
        }

        // ==========================================
        // 3. Тестирование формирования отчёта (.docx)
        // ==========================================

        [TestMethod]
        public void GenerateWord_ValidData_ReturnsEmptyString_AndCreatesFile()
        {
            var generator = new WarehouseWriteOffReportGenerator();
            var records = new List<WarehouseWriteOffRecord>
            {
                new WarehouseWriteOffRecord { Quantity = 10, UnitPrice = 2500m, NomenclatureName = "Деталь А" },
                new WarehouseWriteOffRecord { Quantity = 5,  UnitPrice = 1000m, NomenclatureName = "Деталь Б" }
            };
            var filter = new WarehouseWriteOffFilter
            {
                StartDate = DateTime.Today.AddDays(-30),
                EndDate = DateTime.Today
            };
            string filePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "TestWriteOffReport.docx");

            string result = generator.GenerateWord(records, filter, filePath);

            Assert.AreEqual(string.Empty, result);
            Assert.IsTrue(System.IO.File.Exists(filePath));

            // Очистка после теста
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        [TestMethod]
        public void GenerateWord_EmptyRecords_ReturnsError()
        {
            var generator = new WarehouseWriteOffReportGenerator();
            var records = new List<WarehouseWriteOffRecord>();
            var filter = new WarehouseWriteOffFilter { StartDate = DateTime.Today.AddDays(-1), EndDate = DateTime.Today };

            string result = generator.GenerateWord(records, filter, "test.docx");

            Assert.AreEqual("Нет данных для формирования отчёта.", result);
        }

        [TestMethod]
        public void GenerateWord_InvalidPeriod_ReturnsError()
        {
            var generator = new WarehouseWriteOffReportGenerator();
            var records = new List<WarehouseWriteOffRecord> { new WarehouseWriteOffRecord() };
            var filter = new WarehouseWriteOffFilter
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(-5) // Конец раньше начала
            };

            string result = generator.GenerateWord(records, filter, "test.docx");

            Assert.AreEqual("Дата начала периода не может быть больше даты окончания.", result);
        }

        [TestMethod]
        public void GenerateWord_NullParameters_ReturnsError()
        {
            var generator = new WarehouseWriteOffReportGenerator();
            var filter = new WarehouseWriteOffFilter { StartDate = DateTime.Today, EndDate = DateTime.Today };

            string resultNullRecords = generator.Validate(null, filter);
            string resultNullFilter = generator.Validate(new List<WarehouseWriteOffRecord>(), null);

            Assert.AreEqual("Не переданы записи для формирования отчёта.", resultNullRecords);
            Assert.AreEqual("Не задан период отчёта.", resultNullFilter);
        }
    }
}
