using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class UserPgRepository : IUserRepository
    {
        private readonly string connectionString_ = "Host=localhost;Username=postgres;Password=123;Database=MarsFactoryDB";

        public UserPgRepository()
        {
        }

        public UserPgRepository(string connectionString)
        {
            connectionString_ = connectionString;
        }
        public bool AuthenticateUser(string login, string password)
        {
            var user = GetUserByLogin(login);
            if (user == null)
            {
                return false;
            }

            string hashedPassword = HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }
       

        public User GetUserByLogin(string login)
        {
            User user = null;
            string query = "SELECT * FROM users WHERE login = @login;";

            using (var connection = new NpgsqlConnection(connectionString_))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("login", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                // Читаем значения по именам колонок из PostgreSQL
                                Login = reader["login"].ToString(),
                                PasswordHash = reader["password_hash"].ToString(),
                                Role = (User.UserRole)Enum.Parse(typeof(User.UserRole), reader["role"].ToString())
                            };
                        }
                    }
                }
            }

            return user;
        }
        private string HashPassword(string password) 
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
