using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib;
using System.IO;

namespace YPMarsTests
{
    [TestClass]
    public class OrderReportTests
    {
        [TestMethod]
        public void GetOrderReportData_ExistingOrder_ReturnsDataAndEmptyError()
        {
            var mockRepo = new Mock<IOrderReportRepository>();
            string contractNumber = "ДГ-2026-000001";

            var expectedReport = new OrderReport
            {
                ContractNumber = contractNumber,
                CounterpartyName = "Тестовый контрагент",
                CounterpartyINN = "1234567890",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Товар 1", Quantity = 10, UnitPrice = 100 },
                    new OrderItem { NomenclatureName = "Товар 2", Quantity = 5, UnitPrice = 200 }
                }
            };

            mockRepo.Setup(r => r.GetOrderReportData(contractNumber, out It.Ref<string>.IsAny))
                    .Returns(new GetOrderReportDataDelegate((string c, out string err) =>
                    {
                        err = string.Empty;
                        return expectedReport;
                    }));

            var result = mockRepo.Object.GetOrderReportData(contractNumber, out string actualError);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Items.Count);
            Assert.AreEqual("Тестовый контрагент", result.CounterpartyName);
            Assert.AreEqual(string.Empty, actualError);
        }

        [TestMethod]
        public void GetOrderReportData_OrderNotFound_ReturnsNullAndError()
        {
            var mockRepo = new Mock<IOrderReportRepository>();
            string contractNumber = "ДГ-2026-999999";

            mockRepo.Setup(r => r.GetOrderReportData(contractNumber, out It.Ref<string>.IsAny))
                    .Returns(new GetOrderReportDataDelegate((string c, out string err) =>
                    {
                        err = "Заказ не найден";
                        return null;
                    }));

            var result = mockRepo.Object.GetOrderReportData(contractNumber, out string actualError);

            Assert.IsNull(result);
            Assert.AreEqual("Заказ не найден", actualError);
        }

        [TestMethod]
        public void GetOrderReportData_EmptyOrder_ReturnsReportWithZeroItems()
        {
            var mockRepo = new Mock<IOrderReportRepository>();
            string contractNumber = "ДГ-2026-000002";

            var expectedReport = new OrderReport
            {
                ContractNumber = contractNumber,
                CounterpartyName = "Тестовый контрагент",
                Items = new List<OrderItem>()
            };

            mockRepo.Setup(r => r.GetOrderReportData(contractNumber, out It.Ref<string>.IsAny))
                    .Returns(new GetOrderReportDataDelegate((string c, out string err) =>
                    {
                        err = string.Empty;
                        return expectedReport;
                    }));

            var result = mockRepo.Object.GetOrderReportData(contractNumber, out string actualError);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Items.Count);
            Assert.AreEqual(string.Empty, actualError);
        }

        [TestMethod]
        public void GetOrderReportData_DatabaseError_ReturnsNullAndError()
        {
            var mockRepo = new Mock<IOrderReportRepository>();
            string contractNumber = "ДГ-2026-000001";
            string expectedError = "Ошибка соединения с PostgreSQL";

            mockRepo.Setup(r => r.GetOrderReportData(contractNumber, out It.Ref<string>.IsAny))
                    .Returns(new GetOrderReportDataDelegate((string c, out string err) =>
                    {
                        err = expectedError;
                        return null;
                    }));

            var result = mockRepo.Object.GetOrderReportData(contractNumber, out string actualError);

            Assert.IsNull(result);
            Assert.AreEqual(expectedError, actualError);
        }

        [TestMethod]
        public void Validate_CorrectReport_ReturnsEmptyString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "ДГ-2026-000001",
                CounterpartyName = "ООО Ромашка",
                Items = new List<OrderItem> { new OrderItem { Quantity = 1, UnitPrice = 100 } }
            };

            string result = generator.Validate(report);

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Validate_EmptyItems_ReturnsErrorString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "ДГ-2026-000001",
                CounterpartyName = "ООО Ромашка",
                Items = new List<OrderItem>()
            };

            string result = generator.Validate(report);

            Assert.AreEqual("Невозможно сформировать отчёт: в заказе нет позиций", result);
        }

        [TestMethod]
        public void Validate_MissingCounterparty_ReturnsErrorString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "ДГ-2026-000001",
                CounterpartyName = "",
                Items = new List<OrderItem> { new OrderItem() }
            };

            string result = generator.Validate(report);

            Assert.AreEqual("Не заполнены реквизиты контрагента", result);
        }

        [TestMethod]
        public void Validate_MissingContractNumber_ReturnsErrorString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "",
                CounterpartyName = "ООО Ромашка",
                Items = new List<OrderItem> { new OrderItem() }
            };

            string result = generator.Validate(report);

            Assert.AreEqual("Не заполнен номер договора", result);
        }

        [TestMethod]
        public void GenerateWord_ValidData_CreatesFile()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "ДГ-2026-000001",
                CounterpartyName = "Тестовый контрагент",
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Товар", Quantity = 1, UnitPrice = 100 },
                    new OrderItem { NomenclatureName = "Товар 2", Quantity = 2, UnitPrice = 200 }
                }
            };
            string tempFile = Path.Combine(Path.GetTempPath(), $"order_report_{Guid.NewGuid()}.docx");

            string result = generator.GenerateWord(report, tempFile);

            Assert.AreEqual(string.Empty, result);
            Assert.IsTrue(File.Exists(tempFile));

            if (File.Exists(tempFile)) File.Delete(tempFile);
        }

        [TestMethod]
        public void GenerateWord_NoWritePermissions_ReturnsErrorString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport
            {
                ContractNumber = "ДГ-2026-000001",
                CounterpartyName = "Тестовый контрагент",
                Items = new List<OrderItem> { new OrderItem { Quantity = 1, UnitPrice = 100 } }
            };
            string protectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "test.docx");

            string result = generator.GenerateWord(report, protectedPath);

            Assert.AreEqual("Нет прав на запись файла по указанному пути", result);
        }

        [TestMethod]
        public void GenerateWord_EmptyFilePath_ReturnsErrorString()
        {
            var generator = new OrderReportGenerator();
            var report = new OrderReport();

            string result = generator.GenerateWord(report, "");

            Assert.AreEqual("Не указан путь для сохранения документа", result);
        }

        [TestMethod]
        public void TotalAmount_TwoPositions_CalculatesCorrectly()
        {
            var report = new OrderReport
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 100, UnitPrice = 2500m },
                    new OrderItem { Quantity = 50, UnitPrice = 1800m }
                }
            };

            decimal total = report.TotalAmount;
            int count = report.PositionCount;

            Assert.AreEqual(340000m, total);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TotalAmount_OnePosition_CalculatesCorrectly()
        {
            var report = new OrderReport
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 100, UnitPrice = 2500m }
                }
            };

            decimal total = report.TotalAmount;
            int count = report.PositionCount;

            Assert.AreEqual(250000m, total);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TotalAmount_EmptyItems_ReturnsZero()
        {
            var report = new OrderReport { Items = new List<OrderItem>() };

            decimal total = report.TotalAmount;
            int count = report.PositionCount;

            Assert.AreEqual(0m, total);
            Assert.AreEqual(0, count);
        }
    }
    public delegate OrderReport GetOrderReportDataDelegate(string contractNumber, out string error);
}

