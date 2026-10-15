using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class CreateOrderTest
    {
        // 1. Тестирование генератора номера договора
        [TestMethod]
        public void ContractNumberGenerator_FirstOrderInYear_ReturnsExpected()
        {
            var date = new DateTime(2026, 1, 15);
            int lastNumberInYear = 0;
            var generator = new ContractNumberGenerator();
            string result = generator.Generate(date, lastNumberInYear);
            Assert.AreEqual("ДГ-2026-000001", result);
        }

        [TestMethod]
        public void ContractNumberGenerator_SecondOrderInYear_ReturnsExpected()
        {
            var date = new DateTime(2026, 1, 20);
            int lastNumberInYear = 1;

            var generator = new ContractNumberGenerator();
            string result = generator.Generate(date, lastNumberInYear);

            Assert.AreEqual("ДГ-2026-000002", result);
        }

        [TestMethod]
        public void ContractNumberGenerator_HundredthOrderInYear_ReturnsExpected()
        {
            var date = new DateTime(2026, 6, 1);
            int lastNumberInYear = 99;

            var generator = new ContractNumberGenerator();
            string result = generator.Generate(date, lastNumberInYear);

            Assert.AreEqual("ДГ-2026-000100", result);
        }

        [TestMethod]
        public void ContractNumberGenerator_FirstOrderOfNewYear_ReturnsExpected()
        {
            var date = new DateTime(2027, 1, 5);
            int lastNumberInYear = 0;

            var generator = new ContractNumberGenerator();
            string result = generator.Generate(date, lastNumberInYear);

            Assert.AreEqual("ДГ-2027-000001", result);
        }

        // 2. Тестироваине метола создания заказа (CreateOrder)
        [TestMethod]
        public void CreateOrder_OneItem_ReturnsEmptyString_AndCorrectSum()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2026-000001",
                PlannedShipmentDate = new DateTime(2026, 12, 1),
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Коммутатор КМ-10", Quantity = 100, UnitPrice = 2500.00m }
                }
            };
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.CreateOrder(It.IsAny<Order>()))
                    .Returns(string.Empty);
            IOrderRepository repository = mockRepo.Object;
            string result = repository.CreateOrder(order);
            Assert.AreEqual(string.Empty, result);
            Assert.AreEqual(1, order.Items.Count);
            Assert.AreEqual(250000.00m, order.Items[0].Quantity * order.Items[0].UnitPrice);
            mockRepo.Verify(repo => repo.CreateOrder(It.IsAny<Order>()), Times.Once);
        }

        [TestMethod]
        public void CreateOrder_MultipleItems_ReturnsEmptyString_AndCorrectSum()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2026-000002",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Коммутатор КМ-10", Quantity = 100, UnitPrice = 2500.00m },
                    new OrderItem { NomenclatureName = "Разъём РП-15",    Quantity = 50,  UnitPrice = 1800.00m }
                }
            };

            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.CreateOrder(It.IsAny<Order>()))
                    .Returns(string.Empty);

            IOrderRepository repository = mockRepo.Object;
            string result = repository.CreateOrder(order);

            Assert.AreEqual(string.Empty, result);
            Assert.AreEqual(2, order.Items.Count);

            decimal total = 0;
            foreach (var item in order.Items)
                total += item.Quantity * item.UnitPrice;

            Assert.AreEqual(340000.00m, total);
        }

        [TestMethod]
        public void CreateOrder_DifferentTypesOfNomenclature_ReturnsEmptyString()
        {
            var order = new Order
            {
                ContractNumber = "ДГ-2026-000003",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Клапан электромагнитный КЭМ-10", Quantity = 10, UnitPrice = 5000m },
                    new OrderItem { NomenclatureName = "Блок питания БП-24В",            Quantity = 200, UnitPrice = 150m }
                }
            };

            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.CreateOrder(It.IsAny<Order>()))
                    .Returns(string.Empty);

            IOrderRepository repository = mockRepo.Object;
            string result = repository.CreateOrder(order);

            Assert.AreEqual(string.Empty, result);
            Assert.AreEqual(2, order.Items.Count);
        }

        // 3. Тестирование метода чтения всех заказов (GetAllOrders)

        [TestMethod]
        public void GetAllOrders_EmptyStorage_ReturnsEmptyList()
        {
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetAllOrders())
                    .Returns(new List<Order>());

            IOrderRepository repository = mockRepo.Object;
            var result = repository.GetAllOrders();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetAllOrders_AfterCreateOrder_ReturnsOneOrder()
        {
            var stored = new List<Order>();
            var mockRepo = new Mock<IOrderRepository>();

            mockRepo.Setup(repo => repo.CreateOrder(It.IsAny<Order>()))
                    .Callback<Order>(o => stored.Add(o))
                    .Returns(string.Empty);

            mockRepo.Setup(repo => repo.GetAllOrders())
                    .Returns(() => stored);

            var order = new Order
            {
                ContractNumber = "ДГ-2026-000001",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "Коммутатор КМ-10", Quantity = 100, UnitPrice = 2500m }
                }
            };

            IOrderRepository repository = mockRepo.Object;
            repository.CreateOrder(order);
            var result = repository.GetAllOrders();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ДГ-2026-000001", result[0].ContractNumber);
        }

        // 4. Тестирование Получения последнего номера (GetLastOrderNumberInYear)
        [TestMethod]
        public void GetLastOrderNumberInYear_NoOrders_ReturnsZero()
        {
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetLastOrderNumberInYear(It.IsAny<int>()))
                    .Returns(0);

            IOrderRepository repository = mockRepo.Object;
            int result = repository.GetLastOrderNumberInYear(2026);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetLastOrderNumberInYear_FiveOrders_ReturnsFive()
        {
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetLastOrderNumberInYear(2026))
                    .Returns(5);

            IOrderRepository repository = mockRepo.Object;
            int result = repository.GetLastOrderNumberInYear(2026);

            Assert.AreEqual(5, result);
        }

        // 5. Тестирование валидатора данных
        [TestMethod]
        public void Validate_NullCounterparty_ReturnsError()
        {
            var order = new Order
            {
                CounterpartyName = null,
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "X", Quantity = 1, UnitPrice = 100m }
                }
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual("Выберите контрагента", result);
        }

        [TestMethod]
        public void Validate_NullNomenclature_ReturnsError()
        {
            var order = new Order
            {
                CounterpartyName = "АО Тест",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = null, Quantity = 1, UnitPrice = 100m }
                }
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual("Необходимо выбрать номенклатуру из списка", result);
        }

        [TestMethod]
        public void Validate_QuantityZero_ReturnsError()
        {
            var order = new Order
            {
                CounterpartyName = "АО Тест",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "X", Quantity = 0, UnitPrice = 100m }
                }
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual("Количество должно быть больше нуля", result);
        }

        [TestMethod]
        public void Validate_EmptyItems_ReturnsError()
        {
            var order = new Order
            {
                CounterpartyName = "АО Тест",
                Items = new List<OrderItem>()
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual("Добавьте хотя бы одну позицию в заказ", result);
        }

        [TestMethod]
        public void Validate_PriceNotDefined_ReturnsError()
        {
            var order = new Order
            {
                CounterpartyName = "АО Тест",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "X", Quantity = 1, UnitPrice = 0m }
                }
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual("Не удалось определить цену для выбранной номенклатуры", result);
        }

        [TestMethod]
        public void Validate_ValidOrder_ReturnsEmptyString()
        {
            var order = new Order
            {
                CounterpartyName = "АО Тест",
                Items = new List<OrderItem>
                {
                    new OrderItem { NomenclatureName = "X", Quantity = 1, UnitPrice = 100m }
                }
            };

            var validator = new OrderValidator();
            string result = validator.Validate(order);

            Assert.AreEqual(string.Empty, result);
        }
    }
}
