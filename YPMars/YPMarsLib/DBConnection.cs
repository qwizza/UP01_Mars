using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class DBConnection
    {
        private static string _connectionString;

        static DBConnection()
        {
            _connectionString = "Host=localhost;Username=postgres;Password=123;Database=MarsFactoryDB"; 
        }
        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            return connection;
        }
    }
}
