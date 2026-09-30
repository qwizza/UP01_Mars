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
        private readonly string connectionString_ = "Host=localhost;Username=postgres;Password=123456;Database=MarsFactoryDB";

        public UserPgRepository(string connectionString)
        {
            connectionString_ = connectionString;
        }

        public UserPgRepository()
        {
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
        public bool AddUser(User user)
        {
            string query = "INSERT INTO users (login, password_hash, full_name, department, role) " +
                       "VALUES (@login, @password_hash, @full_name, @department, @role)";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString_))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("login", user.Login);
                        cmd.Parameters.AddWithValue("password_hash", user.PasswordHash);
                        cmd.Parameters.AddWithValue("full_name", user.FullName);
                        cmd.Parameters.AddWithValue("department", user.Department);
                        cmd.Parameters.AddWithValue("role", user.Role.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckIfUserExists(string login)
        {
            string query = "SELECT COUNT(1) FROM users WHERE login = @login";

            using (var connection = new NpgsqlConnection(connectionString_))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("login", login);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static string HashPassword(string password) 
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
