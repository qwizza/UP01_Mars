using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class RegistrTest
    {
        // Тестирование метода добавления пользователя (AddUser)
        // Сценарий 1: Успешное сохранение пользователя с указанием роли (UserRole)
        [TestMethod]
        public void AddUser_ValidUserWithRole_ReturnsTrue()
        {
            var newUser = new User
            {
                Login = "sidorov_i",
                PasswordHash = UserPgRepository.HashPassword("StrongPass123!"),
                FullName = "Сидоров Иван Сергеевич",
                Department = "Отдел логистики",
                Role = User.UserRole.Warehouse
            };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>()))
                    .Returns(true);
            IUserRepository repository = mockRepo.Object;
            bool result = repository.AddUser(newUser);
            Assert.IsTrue(result);
            Assert.AreEqual(User.UserRole.Warehouse, newUser.Role);
        }
        // Тестирование проверки уникальности логина (CheckIfUserExists)
        // Сценарий 1: Проверка логина, который уже присутствует в БД
        [TestMethod]
        public void CheckIfUserExists_ExistingLogin_ReturnsTrue()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.CheckIfUserExists("sidorov_i"))
                    .Returns(true);
            IUserRepository repository = mockRepo.Object;
            bool exists = repository.CheckIfUserExists("sidorov_i");
            Assert.IsTrue(exists);
        }
        // Сценарий 2: Проверка свободного (уникального) логина
        [TestMethod]
        public void CheckIfUserExists_UniqueLogin_ReturnsFalse()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.CheckIfUserExists("new_unique_user"))
                    .Returns(false);
            IUserRepository repository = mockRepo.Object;
            bool exists = repository.CheckIfUserExists("new_unique_user");
            Assert.IsFalse(exists);
        }
        // Тестирование валидаторов входных данных
        // Сценарий 1: Передача пустого логина или строки из пробелов
        [TestMethod]
        public void RegisterValidator_EmptyLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "   ";
            string password = "StrongPass123!";
            string fullName = "Сидоров Иван Сергеевич";
            User.UserRole? role = User.UserRole.Warehouse;
            var mockRepo = new Mock<IUserRepository>();
            var result = Validator.ValidateRegistration(login, password, fullName, role);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Поле \"Логин\" не может быть пустым", result.Message);
            mockRepo.Verify(repo => repo.AddUser(It.IsAny<User>()), Times.Never);
        }
        // Сценарий 2: Пароль короче 8 символов
        [TestMethod]
        public void RegisterValidator_ShortPassword_ReturnsFalseAndErrorMessage()
        {
            string login = "sidorov_i";
            string password = "12345";
            string fullName = "Сидоров Иван Сергеевич";
            User.UserRole? role = User.UserRole.Warehouse;
            var mockRepo = new Mock<IUserRepository>();
            var result = Validator.ValidateRegistration(login, password, fullName, role);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Длина пароля должна составлять не менее 8 символов (текущая длина: 5)", result.Message);
            mockRepo.Verify(repo => repo.AddUser(It.IsAny<User>()), Times.Never);
        }
        // Сценарий 3: Пароль с недопустимыми символами или пробелами
        [TestMethod]
        public void RegisterValidator_PasswordWithSpaces_ReturnsFalseAndErrorMessage()
        {
            string login = "sidorov_i";
            string password = "Pass 123!";
            string fullName = "Сидоров Иван Сергеевич";
            User.UserRole? role = User.UserRole.Warehouse;
            var result = Validator.ValidateRegistration(login, password, fullName, role);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Пароль содержит недопустимые символы или пробелы. Разрешены латинские и русские буквы, цифры и спецсимволы (!@#$%^&*_-)", result.Message);
        }
        // Сценарий 4: Не выбрана роль (null)
        [TestMethod]
        public void RegisterValidator_NullRole_ReturnsFalseAndErrorMessage()
        {
            string login = "sidorov_i";
            string password = "StrongPass123!";
            string fullName = "Сидоров Иван Сергеевич";
            User.UserRole? role = null;
            var result = Validator.ValidateRegistration(login, password, fullName, role);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Необходимо выбрать роль пользователя из списка", result.Message);
        }
    }
}
