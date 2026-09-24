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
        private readonly string connectionString_;
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
            string query = "SELECT login, password_hash, full_name, role FROM users WHERE login = @login";

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
                                Login = reader.GetString(0),
                                PasswordHash = reader.GetString(1),
                                FullName = reader.GetString(2),
                                Role = (User.UserRole)Enum.Parse(typeof(User.UserRole), reader.GetString(3))
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
