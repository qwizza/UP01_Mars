using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public UserRole Role { get; set; }

        // Пустой конструктор (нужен для десериализации и т.п.)
        public User() { }

        // Конструктор для создания нового пользователя
        public User(string login, string passwordHash, UserRole role, string fullName, string department = null)
        {
            Login = login;
            PasswordHash = passwordHash;
            Role = role;
            FullName = fullName;
            Department = department;
        }

        public enum UserRole
        {
            SuperUser,
            ManagerSale,
            Warehouse
        }
    }
}