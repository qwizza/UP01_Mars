using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using YPMarsLib;

namespace YPMarsTests
{
    [TestClass]
    public class AuthTest
    {
        // Тестирование метода проверки учетных данных
        // Сценарий 1: Успешная аутентификация (верная пара логина и пароля)
        [TestMethod]
        public void AuthenticateUser_Success()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.AuthenticateUser("petrov_a", "SecurePass123!"))
                .Returns(true);
            IUserRepository repository = mock.Object;
            bool flag = repository.AuthenticateUser("petrov_a", "SecurePass123!");
            Assert.IsTrue(flag);
        }
        // Сценарий 2: Передача неверного пароля
        [TestMethod]
        public void AuthenticateUser_WrongPassword()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("petrov_a"))
                .Returns(new User { Login = "petrov_a", PasswordHash = "c75d..." });
            IUserRepository repository = mock.Object;
            bool flag = repository.AuthenticateUser("petrov_a", "WrongPassword123!");
            Assert.IsFalse(flag);
        }
        // Сценарий 3: Передача несуществующего логина
        [TestMethod]
        public void AuthenticateUser_NonExistentLogin()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("non_existent_user"))
                .Returns((User)null);
            IUserRepository repository = mock.Object;
            bool flag = repository.AuthenticateUser("non_existent_user", "SecurePass123!");
            Assert.IsFalse(flag);
        }

        //Тестирование получения данных пользователя для главного экрана
        [TestMethod]
        public void GetUserByLoginCorrectData()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.GetUserByLogin("petrov_a"))
                .Returns(new User
                {
                    Login = "petrov_a",
                    FullName = "Петров Алексей Сергеевич",
                    Role = User.UserRole.Warehouser 
                });
            IUserRepository repository = mock.Object;
            User user = repository.GetUserByLogin("petrov_a");
            Assert.IsNotNull(user);
            Assert.AreEqual("Петров Алексей Сергеевич", user.FullName);
            Assert.AreEqual(User.UserRole.Warehouser, user.Role);
        }

        //Тест валидатора длины и алфавита пароля
        //Сценарий 1: Пароль короче 8 символов
        [TestMethod]
        public void Password_Short()
        {
            string password = "12345";
            var result = AuthValidator.ValidatePassword(password);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Длина пароля должна составлять не менее 8 символов (текущая длина: 5)", result.Message);
        }
        //Сценарий 2: Пароль содержит пробелы
        [TestMethod]
        public void Password_Spaces()
        {
            string password = "Pass 123!";
            var result = AuthValidator.ValidatePassword(password);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Пароль содержит недопустимые символы или пробелы. Разрешены латинские и русские буквы, цифры и спецсимволы (!@#$%^&*_-)", result.Message);
        }
    }
}
