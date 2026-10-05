using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class Validator
    {
        public static (bool IsValid, string Message) ValidateLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return (false, "Поле \"Логин\" не может быть пустым");
            }
            return (true, string.Empty);
        }
        public static (bool IsValid, string Message) ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                int currentLength = password?.Length ?? 0;
                return (false, $"Длина пароля должна составлять не менее 8 символов (текущая длина: {currentLength})");
            }
            string pattern = @"^[A-Za-zА-Яа-я0-9!@#$%^&*_\-]+$";
            if (!Regex.IsMatch(password, pattern))
            {
                return (false, "Пароль содержит недопустимые символы или пробелы. Разрешены латинские и русские буквы, цифры и спецсимволы (!@#$%^&*_-)");
            }
            return (true, string.Empty);
        }
        public static (bool IsValid, string Message) ValidateRegistration(string login, string password, string fullName, User.UserRole? role)
        {
            var loginResult = ValidateLogin(login);
            if (!loginResult.IsValid)
            {
                return loginResult;
            }
            var passwordResult = ValidatePassword(password);
            if (!passwordResult.IsValid)
            {
                return passwordResult;
            }
            if (role == null)
            {
                return (false, "Необходимо выбрать роль пользователя из списка");
            }
            return (true, string.Empty);
        }
    }
}
